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
    public class Locations
    {
        [TestMethod]
        public void GetLocation()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<Location> loc = api.Locations.Get("1");
                Assert.AreEqual(200, loc.meta.code);
                Assert.IsNotNull(loc.data);
                Console.WriteLine(loc.data.name);
            }
        }
        [TestMethod]
        public void FeedsOfLocationFromId()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                IResponse<IEnumerable<Feed>> media = api.Locations.Feeds("1");
                Assert.AreEqual(200, media.meta.code);
                Assert.IsNotNull(media.data);
                Console.WriteLine(media.data.FirstOrDefault().user.username);
            }
        }
        [TestMethod]
        public void LocationsFromLatLng()
        {
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
                //Izmir, 3km
                IResponse<IEnumerable<Location>> media = api.Locations.Search("38.41885", "27.12872", "3000");
                Assert.AreEqual(200, media.meta.code);
                Assert.IsNotNull(media.data);
                Console.WriteLine(media.data.FirstOrDefault().name);
            }
        }
    }
}
