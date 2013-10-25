using InstaNET.Model;
using InstaNET.Response;
using System.Collections.Generic;

namespace InstaNET
{
    public class Geographies
    {
        private readonly TokenManager token;
        private const string GeoAPIBase = "https://api.instagram.com/v1/geographies/";
        internal Geographies(ref TokenManager _token)
        {
            token = _token;
        }
        public IResponse<IEnumerable<Feed>> Media(string geo_id, string count = null, string min_id = null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(GeoAPIBase, new string[] { geo_id,"media","recent" }, new Dictionary<string, string> { 
                {"count",count}, {"min_id",min_id}
            }, token, Method.GET, true) as Response<IEnumerable<Feed>>;
            return feeds;
        }
    }
}
