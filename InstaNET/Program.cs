using Instagram.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class Program
    {
        static void Main(string[] args)
        {
            InstagramAPI api = new InstagramAPI(new TokenManager(_consumerKey: "a9beaa9c190649d18cdd99847d7261b8"));
            UserResponse response = api.Users.BasicInfo("544232100");
            var x = 10;
        }
    }
}
