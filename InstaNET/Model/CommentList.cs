using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET.Model
{
   public class CommentList
    {
        public int count { get; set; }
        public IEnumerable<Comment> data { get; set; }
    }
}
