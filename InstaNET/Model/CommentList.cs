using System.Collections.Generic;

namespace InstaNET.Model
{
   public class CommentList
    {
        public int count { get; set; }
        public IEnumerable<Comment> data { get; set; }
    }
}
