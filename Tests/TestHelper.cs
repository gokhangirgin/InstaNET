using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaNET;
namespace Tests
{
    public static class TestHelper
    {
        public static TokenManager Token { get { 
            return new TokenManager(_accessToken:"",_clientId:""); // Put here an access token or client id of your application
        } }
        public static string MediaId { get {
            return "564606726137161734_301763305"; //adriana Lima's media :)
        } }
        public static string UserId { get {
            return "301763305"; //adriana Lima's Id ^^
        } }



    }
}
