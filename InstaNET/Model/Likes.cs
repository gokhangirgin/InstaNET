using System.Collections.Generic;

namespace InstaNET.Model
{
    public class Likes
    {
        public int count { get; set; }
        public IEnumerable<UserInfo> data { get; set; }
    }
}
