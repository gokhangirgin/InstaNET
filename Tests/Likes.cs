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
    public class Likes
    {
        
        [TestMethod]
        public void GetLikesOfAnMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<UserInfo>> likes = api.Likes.GetLikes(TestHelper.MediaId);
                Assert.AreEqual(200, likes.meta.code);
                Assert.IsNotNull(likes.data); //It is impossible for this media
                Console.WriteLine(likes.data.FirstOrDefault().username);
            }
        }
        [TestMethod]
        public void LikeThatMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<object> l = api.Likes.NewLike(TestHelper.MediaId);
                Assert.AreEqual(200, l.meta.code);
                Console.WriteLine(l);
            }
        }
        [TestMethod]
        public void UnlikeThatMedia()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<object> l = api.Likes.RemoveLike(TestHelper.MediaId);
                Assert.AreEqual(200, l.meta.code);
                Console.WriteLine(l);
            }
        }
    }
}
