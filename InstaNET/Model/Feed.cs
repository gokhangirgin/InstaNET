using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET.Model
{
    public class Feed
    {
        public IEnumerable<string> tags { get; set; }
        public GeoLoc location { get; set; }
        public CommentList comments { get; set; }
        public string filter { get; set; }
        public long created_time { get; set; }
        public string link { get; set; }
        public Likes likes { get; set; }
        public Images images { get; set; }
        public Images videos { get; set; }
        public IEnumerable<TaggedUsers> users_in_photo { get; set; }
        public Comment caption { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public UserInfo user { get; set; }
        public bool user_has_liked { get; set; }
    }
}
