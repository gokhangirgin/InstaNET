using InstaNET.Model;
using InstaNET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET
{
    public enum RelationShipAction
    { 
        follow,unfollow,block,unblock,approve,deny
    }
    public enum Method
    { 
        GET,POST,DELETE
    }
    public class Relationships
    {
        private readonly TokenManager token;
        private const string RelationshipsAPIBase = "https://api.instagram.com/v1/users/";
        internal Relationships(ref TokenManager _token)
        {
            token = _token;
        }
        /// <summary>
        /// Verilen id'nin takip ettiği kullanıcılar
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IResponse<IEnumerable<UserInfo>> Follows(string user_id)
        {
            IResponse<IEnumerable<UserInfo>> follows = new Response<IEnumerable<UserInfo>>();
            follows = follows.MakeAPIRequest(RelationshipsAPIBase, new string[] { user_id,"follows" }, null, token, Method.GET) as Response<IEnumerable<UserInfo>>;
            return follows;
        }
        /// <summary>
        /// Açık profillerde kullanıcının ID'si verilerek client_id ile yapılabilir. Kilitli profillerde access token gerekir.
        /// Using client_id you can fetch followers of an user_id which is public. Private accounts requires access token.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IResponse<IEnumerable<UserInfo>> FollowedBy(string user_id)
        {
            IResponse<IEnumerable<UserInfo>> followedBy = new Response<IEnumerable<UserInfo>>();
            followedBy = followedBy.MakeAPIRequest(RelationshipsAPIBase, new string[] { user_id, "followed-by" }, null, token, Method.GET) as Response<IEnumerable<UserInfo>>;
            return followedBy;
        }
        /// <summary>
        /// Kilitli hesaplar için takip etme istekleri
        /// People who'd like to follow authorized user(requires access token)
        /// </summary>
        /// <returns></returns>
        public IResponse<IEnumerable<UserInfo>> RequestedBy()
        {
            IResponse<IEnumerable<UserInfo>> requestedBy = new Response<IEnumerable<UserInfo>>();
            requestedBy = requestedBy.MakeAPIRequest(RelationshipsAPIBase, new string[] { "self", "requested-by" }, null, token, Method.GET, true) as Response<IEnumerable<UserInfo>>;
            return requestedBy;
        }
        /// <summary>
        /// Relationship status between authorized user(access token) and user_id
        /// </summary>
        /// <param name="user_id">What's my relationship with this user</param>
        /// <returns></returns>
        public IResponse<RelationshipStatus> Status(string user_id)
        {
            IResponse<RelationshipStatus> relationship = new Response<RelationshipStatus>();
            relationship = relationship.MakeAPIRequest(RelationshipsAPIBase, new string[] { user_id, "relationship" }, null, token, Method.GET, true) as Response<RelationshipStatus>;
            return relationship;
        }
        /// <summary>
        /// Yeni bir ilişki oluşturmak için, RelationShipAction enum olduğundan anlaşılması daha kolay.
        /// Creates new relationship between authorized user(access token) and target user_id
        /// </summary>
        /// <param name="user_id">target identity of an user</param>
        /// <param name="action">follow/unfollow etc..</param>
        /// <returns></returns>
        public IResponse<RelationshipStatus> New(string user_id,RelationShipAction action)
        {
            IResponse<RelationshipStatus> rs = new Response<RelationshipStatus>();
            rs = rs.MakeAPIRequest(RelationshipsAPIBase, new string[] { user_id, "relationship" }, 
                new Dictionary<string, string> { {"action",action.ToString()} }, 
                token, Method.POST, true);
            return rs;
        }
    }
}
