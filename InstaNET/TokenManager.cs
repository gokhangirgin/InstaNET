using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET
{
    public class TokenManager
    {
        public string accessToken { get; private set; }
        public string clientId { get; private set; }
        public TokenManager(string _accessToken=null, string _clientId=null)
        {
            accessToken = _accessToken;
            clientId = _clientId;
            if(string.IsNullOrEmpty(accessToken) && string.IsNullOrEmpty(clientId))
                throw new ArgumentException("must be provided access token or client id");
        }
    }
}
