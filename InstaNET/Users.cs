using InstaNET.Model;
using InstaNET.Response;
using System.Collections.Generic;
using System.Web;
namespace InstaNET
{
    public class Users
    {

        private readonly TokenManager token;
        private const string UsersAPIBase = "https://api.instagram.com/v1/users/";

        internal Users(ref TokenManager _token) { token = _token; }

        public IResponse<UserInfo> BasicInfo(string user_id)
        {
            IResponse<UserInfo> userInfo = new Response<UserInfo>();
            userInfo = userInfo.MakeAPIRequest(UsersAPIBase, new string[] { user_id }, null, token, Method.GET) as Response<UserInfo>;
            return userInfo;
        }

        public IResponse<IEnumerable<Feed>> SelfFeed(string count = null, string min_id = null, string max_id = null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(UsersAPIBase, new string[] { "self", "feed" }, new Dictionary<string, string> { { "count", count }, 
                { "max_id", max_id }, { "min_id", min_id } }, token, Method.GET, true) as Response<IEnumerable<Feed>>;
            return feeds;
        }

        public IResponse<IEnumerable<Feed>> RecentMedia(string userId, long? max_timestamp = null, long? min_timestamp = null, string count = null, string min_id = null, string max_id = null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(UsersAPIBase, new string[] { userId, "media", "recent" }, new Dictionary<string, string> { { "count", count }, 
                { "max_id", max_id }, { "min_id", min_id },{"min_timestamp",min_timestamp.HasValue ? min_timestamp.Value.ToString() : null},
                {"max_timestamp",max_timestamp.HasValue ? max_timestamp.Value.ToString() : null} }, token, Method.GET, true) as Response<IEnumerable<Feed>>;
            return feeds;
        }
        public IResponse<IEnumerable<Feed>> LikedMedia(string count = null, string max_like_id=null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(UsersAPIBase, new string[] { "self", "media", "liked" }, 
                new Dictionary<string, string> { { "count", count }, { "max_like_id", max_like_id } },
                token, Method.GET, true) as Response<IEnumerable<Feed>>;
            return feeds;
        }
        public IResponse<IEnumerable<UserInfo>> Search(string q, string count = null)
        {
            var usr = new Response<IEnumerable<UserInfo>>();
            usr = usr.MakeAPIRequest(UsersAPIBase, new string[] { "search" }, 
                new Dictionary<string, string> { { "q", HttpUtility.UrlEncode(q) }, { "count", count } },
                token, Method.GET) as Response<IEnumerable<UserInfo>>;
            return usr;
        }
    }
}
