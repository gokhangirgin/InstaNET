using InstaNET.Model;
using InstaNET.Response;
using System.Collections.Generic;

namespace InstaNET
{
    public class Media
    {
        private readonly TokenManager token;
        private const string MediaAPIBase = "https://api.instagram.com/v1/media/";
        internal Media(ref TokenManager _token)
        {
            token = _token;
        }
        public IResponse<Feed> Get(string media_id)
        {
            IResponse<Feed> feed = new Response<Feed>();
            feed = feed.MakeAPIRequest(MediaAPIBase, new string[] { media_id }, null, token, Method.GET) as Response<Feed>;
            return feed;
        }
        public IResponse<IEnumerable<Feed>> Search(string lat = null, string lng = null, string min_timestamp=null, string max_timestamp = null,string distance=null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(MediaAPIBase, new string[] { "search" },
                new Dictionary<string, string> { {"lng",lng}, {"lat", lat},
                {"min_timestamp",min_timestamp}, {"max_timestamp",max_timestamp},
                {"distance", distance}},
                token, Method.GET) as Response<IEnumerable<Feed>>;
            return feeds;
        }
        public IResponse<IEnumerable<Feed>> Popular(string count = null, string max_id = null, string min_id = null)
        {
            IResponse<IEnumerable<Feed>> feed = new Response<IEnumerable<Feed>>();
            feed = feed.MakeAPIRequest(MediaAPIBase, new string[] { "popular" }, 
                new Dictionary<string, string> { { "count", count }, 
                { "max_id", max_id }, { "min_id", min_id } }, token, Method.GET) as Response<IEnumerable<Feed>>;
            return feed;
        }
    }
}
