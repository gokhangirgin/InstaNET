using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET.Response
{
    public class RateLimit
    {
        public int MaxLimit { get; set; }
        public int RemainingLimit { get; set; }
    }
}
