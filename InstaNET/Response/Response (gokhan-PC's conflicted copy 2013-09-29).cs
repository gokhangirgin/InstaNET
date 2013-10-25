using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Response
{
    class Response<T> : IResponse<T>
    {
        public RateLimit limit
        {
            get;
            set;
        }

        public Model.meta meta
        {
            get;
            set;
        }

        public T data
        {
            get;
            set;
        }

        public Model.pagination pagination
        {
            get;
            set;
        }

        public string accessToken
        {
            get;
            set;
        }
    }
}
