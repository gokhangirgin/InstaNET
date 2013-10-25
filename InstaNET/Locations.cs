using InstaNET.Model;
using InstaNET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET
{
    public class Locations
    {
        private readonly TokenManager token;
        private const string LocationsAPIBase = "https://api.instagram.com/v1/locations/";
        internal Locations(ref TokenManager _token)
        {
            token = _token;
        }
        public IResponse<Location> Get(string location_id)
        {
            IResponse<Location> loc = new Response<Location>();
            loc = loc.MakeAPIRequest(LocationsAPIBase, new string[] { location_id }, null, token, Method.GET) as Response<Location>;
            return loc;
        }
        public IResponse<IEnumerable<Feed>> Feeds(string location_id)
        {
            IResponse<IEnumerable<Feed>> feeds = new Response<IEnumerable<Feed>>();
            feeds = feeds.MakeAPIRequest(LocationsAPIBase, new string[] { location_id, "media", "recent" }, null, token, Method.GET) as Response<IEnumerable<Feed>>;
            return feeds;
        }
        public IResponse<IEnumerable<Location>> Search(string lat = null, string lng = null, string distance = null, string foursquare_id = null, string foursquare_v2_id = null)
        {
            IResponse<IEnumerable<Location>> loc = new Response<IEnumerable<Location>>();
            loc = loc.MakeAPIRequest(LocationsAPIBase, new string[] { "search" },
                new Dictionary<string, string> { { "lat", lat }, 
                { "lng", lng }, { "distance", distance }, { "foursquare_id", foursquare_id }, { "foursquare_v2_id", foursquare_v2_id } },
                token, Method.GET) as Response<IEnumerable<Location>>;
            return loc;
        }
    }
}
