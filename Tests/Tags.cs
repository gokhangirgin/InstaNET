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
    public class Tags
    {
        [TestMethod]
        public void TagInfo()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<TagInfo> tag = api.Tags.Info("instagood");
                Assert.AreEqual(200, tag.meta.code);
                Assert.IsNotNull(tag.data);
                Console.WriteLine(tag.data.name);
            }
        }
        [TestMethod]
        public void FeedsFromTagName()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> feed = api.Tags.Feeds("instagood");
                Assert.AreEqual(200, feed.meta.code);
                Assert.IsNotNull(feed.data);
                Console.WriteLine(feed.data.FirstOrDefault().user.username);
            }
        }
        [TestMethod]
        public void TagSearch()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<TagInfo>> tags = api.Tags.Search("insta");
                Assert.AreEqual(200, tags.meta.code);
                Assert.IsNotNull(tags.data);
                Console.WriteLine(tags.data.FirstOrDefault().name);
            }
             
        }
    }
}
