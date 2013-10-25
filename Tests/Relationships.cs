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
    public class Relationships
    {
        [TestMethod]
        public void Follows()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<UserInfo>> follows = api.Relationships.Follows(TestHelper.UserId);
                Assert.AreEqual(200, follows.meta.code);
                Assert.IsNotNull(follows.data);
                Console.WriteLine(follows.data.FirstOrDefault().username);
            }
        }
        [TestMethod]
        public void FollowedBy()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<UserInfo>> followed = api.Relationships.FollowedBy(TestHelper.UserId);
                Assert.AreEqual(200, followed.meta.code);
                Assert.IsNotNull(followed.data);
                Console.WriteLine(followed.data.FirstOrDefault().username);
            }
        }
        [TestMethod]
        public void RequestedBy()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<UserInfo>> requested = api.Relationships.RequestedBy();
                Assert.AreEqual(200, requested.meta.code);
                //Assert.IsNotNull(followed.data); can be null because account may be public,
                
            }
        }
        [TestMethod]
        public void RelationshipStatus()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<RelationshipStatus> status = api.Relationships.Status(TestHelper.UserId); //between adriana lima and user of token
                Assert.AreEqual(200, status.meta.code);
                Assert.IsNotNull(status.data);
                Console.WriteLine(string.Format("Outgoing : {0} , Incoming : {1}",status.data.outgoing_status,status.data.incoming_status));
            }
        }
        [TestMethod]
        public void Follow()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                //follow
                IResponse<RelationshipStatus> status = api.Relationships.New(TestHelper.UserId, RelationShipAction.follow);
                Assert.AreEqual(200, status.meta.code);
                Assert.AreEqual(status.data.outgoing_status, "follows");
                Assert.IsNotNull(status.data);
                Console.WriteLine(status.data.outgoing_status);
            }
        }
        [TestMethod]
        public void UnFollow() // :((
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                //unfollow
                IResponse<RelationshipStatus> status = api.Relationships.New(TestHelper.UserId, RelationShipAction.unfollow); //between adriana lima and user of token
                Assert.AreEqual(200, status.meta.code);
                Assert.IsNotNull(status.data);
                Assert.AreEqual(status.data.outgoing_status, "none");
                Console.WriteLine(status.data.outgoing_status);
            }
        }
    }
}
