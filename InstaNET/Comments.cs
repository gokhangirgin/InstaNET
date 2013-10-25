using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaNET.Model;
using InstaNET.Response;
namespace InstaNET
{
    public class Comments
    {
        private readonly TokenManager token;
        private const string commentAPIBase = "https://api.instagram.com/v1/media/";

        internal Comments(ref TokenManager _token)
        {
            token = _token;
        }
        public IResponse<IEnumerable<Comment>> GetComments(string media_id)
        {
            IResponse<IEnumerable<Comment>> comments = new Response<IEnumerable<Comment>>();
            comments = comments.MakeAPIRequest(commentAPIBase, new string[] { media_id, "comments" }, null, token, Method.GET) as Response<IEnumerable<Comment>>;
            return comments;
        }
        public IResponse<Comment> NewComment(string media_id, string text)
        {
            IResponse<Comment> comments = new Response<Comment>();
            comments = comments.MakeAPIRequest(commentAPIBase, new string[] { media_id, "comments" },
                new Dictionary<string, string> { { "text", text } }, token, Method.POST, accessToken: true) as Response<Comment>;
            return comments;
        }
        public IResponse<Comment> RemoveComment(string media_id, string comment_id)
        {
            IResponse<Comment> comments = new Response<Comment>();
            comments = comments.MakeAPIRequest(commentAPIBase, new string[] { media_id, "comments",comment_id },
               null, token, Method.DELETE, accessToken: true) as Response<Comment>;
            return comments;
        }
    }
}
