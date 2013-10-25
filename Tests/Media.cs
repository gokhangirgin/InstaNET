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
    public class Media
    {
        [TestMethod]
        public void GetMediaFromId()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<Feed> media = api.Media.Get(TestHelper.MediaId);
                Assert.AreEqual(200, media.meta.code);
                Assert.IsNotNull(media.data);
                Console.WriteLine(media.data.user.username);
            }
        }
        [TestMethod]
        public void GetPopularMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> media = api.Media.Popular(count:"50");
                Assert.AreEqual(200, media.meta.code);
                Assert.IsNotNull(media.data);
                Console.WriteLine(media.data.FirstOrDefault().user.username);
            }
        }
        [TestMethod]
        public void SearchMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> media = api.Media.Search(lat: "38.41885", lng: "27.12872", distance: "5000");
                Assert.AreEqual(200, media.meta.code);
                Assert.IsNotNull(media.data);
                Console.WriteLine(media.data.FirstOrDefault().user.username);
            }
        }
    }
}
