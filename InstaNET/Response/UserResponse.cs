using Instagram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Response
{
    public class UserResponse : IResponse<UserInfo>
    {
        public meta meta
        {
            get;
            set;
        }

        public UserInfo data
        {
            get;
            set;
        }

        public pagination pagination
        {
            get;
            set;
        }

        public RateLimit limit { get; set; }
    }
}
