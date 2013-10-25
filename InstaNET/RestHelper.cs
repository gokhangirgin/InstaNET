using InstaNET.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
namespace InstaNET
{
    public static class RestHelper
    {
        public static IResponse<T> MakeAPIRequest<T>(this IResponse<T> str, string baseURI, string[] paths, Dictionary<string, string> qstr, TokenManager token, Method method, bool accessToken = false)
        {
            if (accessToken && string.IsNullOrEmpty(token.accessToken))
                throw new InvalidOperationException("This method requires access token!");
            HttpWebRequest request;
            HttpWebResponse response;
            switch (method)
            {
                case Method.DELETE:
                case Method.GET:
                    request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}{2}", baseURI, String.Join("/", paths), BuildQueryString(qstr, token)));
                    break;
                case Method.POST:
                    {
                        request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}{2}", baseURI, String.Join("/", paths), BuildQueryString(qstr, token, method)));
                        request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                        request.Referer = "http://localhost:55882";
                        request.Method = Method.POST.ToString(); // without method here getting exception *Cannot send a content-body with this verb-type*
                        if (qstr != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var item in qstr)
                            {
                                sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                            }
                            sb = sb.Remove(sb.Length - 1, 1);//remove last &
                            byte[] data = Encoding.UTF8.GetBytes(sb.ToString());
                            request.ContentLength = data.Length;
                            using (Stream sr = request.GetRequestStream())
                            {
                                sr.Write(data, 0, data.Length);
                            }
                        }
                    }
                    break;
                default:
                    throw new NotSupportedException("method is not supported yet!.");
            }
            request.Method = method.ToString();
            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    str = (IResponse<T>)JsonConvert.DeserializeObject(sr.ReadToEnd(), type: str.GetType(), settings: new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    str.limit = new RateLimit { MaxLimit = Convert.ToInt32(response.Headers["X-Ratelimit-Limit"]), RemainingLimit = Convert.ToInt32(response.Headers["X-Ratelimit-Remaining"]) };
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (str.meta.code != 200)
                            throw new Exception(string.Format("Error Type: {0} ### Error Message : {1}", str.meta.error_type, str.meta.error_message));
                        return str;
                    }
                    else
                    {
                        throw new Exception(string.Format("Error Type: {0} ### Error Message : {1}", str.meta.error_type, str.meta.error_message));
                    }
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                using (StreamReader sr = new StreamReader(stream))
                {
                    str = (IResponse<T>)JsonConvert.DeserializeObject(sr.ReadToEnd(), type: str.GetType(), settings: new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    throw new WebException(string.Format("Error Type: {0} # Error Message : {1}", str.meta.error_type, str.meta.error_message));
                }
            }
        }
        private static string BuildQueryString(Dictionary<string, string> qstr, TokenManager token, Method method = Method.GET)
        {
            StringBuilder str = new StringBuilder();
            str.Append("?");
            if (!string.IsNullOrEmpty(token.accessToken))
                str.AppendFormat("access_token={0}", token.accessToken);
            else if (!string.IsNullOrEmpty(token.clientId))
                str.AppendFormat("client_id={0}", token.clientId);
            else
                throw new ArgumentException("Client Id or Access Token must be provided");
            if (method != Method.POST)
            {
                if (qstr != null)
                {
                    foreach (var item in qstr)
                    {
                        if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value))
                            str.AppendFormat("&{0}={1}", item.Key, item.Value);
                    }
                }
            }
            return str.ToString();
        }
    }
}
