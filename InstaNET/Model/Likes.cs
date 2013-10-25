using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET.Model
{
    public class Likes
    {
        public int count { get; set; }
        public IEnumerable<UserInfo> data { get; set; }
    }
}
