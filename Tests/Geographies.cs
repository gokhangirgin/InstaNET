using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstaNET;
using InstaNET.Response;
using System.Collections.Generic;
using InstaNET.Model;

namespace Tests
{
    [TestClass]
    public class Geographies
    {
        [TestMethod]
        public void MediaFromGeopgrapyId()
        {
            /*
             * Need valid geo_id to test
            using (InstagramAPI api = new InstagramAPI(TestHelper.Token))
            {
               IResponse<IEnumerable<Feed>> locations = api.Geographies.Media(geo_id:"",count:"50");
               Assert.AreEqual(200, locations.meta.code);
               Assert.IsNotNull(locations.data);
            }*/
        }
    }
}
