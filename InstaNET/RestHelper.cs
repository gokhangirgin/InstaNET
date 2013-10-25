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
        public static IResponse<T> MakeAPIRequest<T>(this IResponse<T> str, string baseURI, string[] paths, Dictionary<string, string> qstr, TokenManager token, Method method,bool accessToken = false)
        {
            if (accessToken && string.IsNullOrEmpty(token.accessToken))
                throw new InvalidOperationException("This method requires access token!");
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(baseURI) })
            {
                try
                {
                    HttpResponseMessage response;
                    switch (method)
                    {
                        case Method.DELETE: case Method.GET:
                            response = client.GetAsync(string.Format("{0}{1}",String.Join("/", paths), BuildQueryString(qstr, token))).Result;
                            break;
                        case Method.POST:
                            {
                                HttpContent postData = null;
                                response = client.PostAsync(string.Format("{0}{1}",String.Join("/", paths), BuildQueryString(qstr, token)), postData).Result;
                            }
                            break;
                        default:
                            throw new NotSupportedException("method is not supported yet!.");
                    }
                    str = (IResponse<T>)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, type: str.GetType(), settings: new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    str.limit = new RateLimit { MaxLimit = Convert.ToInt32(response.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault()), RemainingLimit = Convert.ToInt32(response.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault()) };
                    return str;
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
