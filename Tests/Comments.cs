using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstaNET;
using InstaNET.Response;
using System.Collections.Generic;
using InstaNET.Model;
using System.Linq;
namespace Tests
{
    [TestClass]
    public class Comments
    {
        [TestMethod]
        public void GetComments()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Comment>> comments = api.Comments.GetComments(TestHelper.MediaId);
                Assert.AreEqual(200, comments.meta.code);
                Assert.IsNotNull(comments.data);
                Console.WriteLine(comments.data.First().text);
            }
        }
        /// <summary>
        /// Adding or removing comments requires whitelisting http://bit.ly/instacomments
        /// </summary>
        [TestMethod]
        public void NewComment()
        {
            /*
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<Comment> comments = api.Comments.NewComment(TestHelper.MediaId,"Hello :) #beauty");
                Assert.AreEqual(200, comments.meta.code);
                Assert.IsNotNull(comments.data);
            }*/
        }
        [TestMethod]
        public void RemoveComment()
        {
            /*
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<Comment> comments = api.Comments.RemoveComment(TestHelper.MediaId, "commentId");
                Assert.AreEqual(200, comments.meta.code);
                Assert.IsNotNull(comments.data);
            }*/
        }
    }
}
