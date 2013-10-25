using InstaNET.Model;
using InstaNET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET
{
    public class Likes
    {
        private readonly TokenManager token;
        private const string LikesAPIBase = "https://api.instagram.com/v1/media/";
        internal Likes(ref TokenManager _token)
        {
            token = _token;
        }
        public IResponse<IEnumerable<UserInfo>> GetLikes(string media_id)
        {
            IResponse<IEnumerable<UserInfo>> likes = new Response<IEnumerable<UserInfo>>();
            likes = likes.MakeAPIRequest(LikesAPIBase, new string[] { media_id, "likes" }, null, token, Method.GET) as Response<IEnumerable<UserInfo>>;
            return likes;
        }
        public IResponse<object> NewLike(string media_id)
        {
            IResponse<object> like = new Response<object>();
            like = like.MakeAPIRequest(LikesAPIBase, new string[] { media_id, "likes" }, null, token, Method.POST, true) as Response<object>;
            return like;
        }
        public IResponse<object> RemoveLike(string media_id)
        {
            IResponse<object> like = new Response<object>();
            like = like.MakeAPIRequest(LikesAPIBase, new string[] { media_id, "likes" }, null, token, Method.DELETE, true) as Response<object>;
            return like;
        }
    }
}
