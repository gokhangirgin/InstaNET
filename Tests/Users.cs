using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstaNET;
using InstaNET.Response;
using InstaNET.Model;
using System.Collections.Generic;
using System.Linq;
namespace Tests
{

    [TestClass]
    public class Users
    {
        [TestMethod]
        public void BasicInfo()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
               IResponse<UserInfo> userInfo = api.Users.BasicInfo("544232100");
               Assert.AreEqual(200, userInfo.meta.code);
               Console.WriteLine(userInfo.data.username);
               Assert.AreNotEqual(0, userInfo.limit.RemainingLimit);
               Console.WriteLine(userInfo.data.username);
               
            }
        }
        [TestMethod]
        public void SelfFeed()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> feed = api.Users.SelfFeed();
                Assert.AreEqual(200, feed.meta.code);
                Console.WriteLine(feed.data.FirstOrDefault().user.username);
            }
        }

        [TestMethod]
        public void RecentMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> feed = api.Users.RecentMedia("544232100");
                Assert.AreEqual(200, feed.meta.code);
                Assert.IsNotNull(feed.data);
                Console.WriteLine(feed.data.FirstOrDefault().user.username);
            }
        }
        [TestMethod]
        public void Search()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<UserInfo>> feed = api.Users.Search("girgingokhan");
                Assert.AreEqual(200, feed.meta.code);
                Assert.IsNotNull(feed.data);
                Console.WriteLine(feed.data.FirstOrDefault().username);
            }
        }
    }
}
