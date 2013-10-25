using InstaNET.Model;
using InstaNET.Response;
using System.Collections.Generic;
using System.Web;

namespace InstaNET
{
    public class Tags
    {
        private readonly TokenManager token;
        private const string TagsBaseAPI = "https://api.instagram.com/v1/tags/";
        internal Tags(ref TokenManager _token)
        {
            token = _token;
        }
        /// <summary>
        /// Tag meta
        /// </summary>
        /// <param name="tag_name">tag name #{izmir}</param>
        /// <returns></returns>
        public IResponse<TagInfo> Info(string tag_name)
        {
            IResponse<TagInfo> tag = new Response<TagInfo>();
            tag = tag.MakeAPIRequest(TagsBaseAPI, new string[] { tag_name }, null, token, Method.GET);
            return tag;
        }
        /// <summary>
        /// Bu etiket için son resimler.
        /// </summary>
        /// <param name="tag_name">#{ like }</param>
        /// <param name="min_id"></param>
        /// <param name="max_id"></param>
        /// <returns></returns>
        public IResponse<IEnumerable<Feed>> Feeds(string tag_name, string min_id = null, string max_id=null)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(TagsBaseAPI, new string[] { tag_name, "media", "recent" },
                new Dictionary<string, string> { { "min_id", min_id}, { "max_id", max_id} }, 
                token ,method: Method.GET) as Response<IEnumerable<Feed>>;
            return feeds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q">tag arama</param>
        /// <returns></returns>
        public IResponse<IEnumerable<TagInfo>> Search(string q)
        {
            IResponse<IEnumerable<TagInfo>> tags = new Response<IEnumerable<TagInfo>>();
            tags = tags.MakeAPIRequest(TagsBaseAPI, new string[] { "search" }, 
                new Dictionary<string, string> { { "q", HttpUtility.UrlEncode(q) } }, 
                token, Method.GET) as Response<IEnumerable<TagInfo>>;
            return tags;
        }
    }
}
