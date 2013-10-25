using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaNET
{
    public class InstagramAPI : IDisposable
    {
        private TokenManager token;
        private Users _users;
        private Media _media;
        private Relationships _relationships;
        private Comments _comments;
        private Likes _likes;
        private Tags _tags;
        private Locations _locations;
        private Geographies _geo;
        public InstagramAPI(TokenManager _token)
        {
            //InstagramAPI api = new InstagramAPI(new TokenManager(_clientId: "a9beaa9c190649d18cdd99847d7261b8"));
            //FeedResponse response = api.Users.SelfFeed();
            //var usr = api.Users.Search("gokhan girgin", "10");
            //var rs = api.Relationships.New("544232100",RelationShipAction.follow);
            //var rs = api.Locations.Get("11");
            token = _token;
        }

        public Users Users { get {
            if (_users == null)
                _users = new Users(ref token);
            return _users;
        } }
        public Media Media { get {
            if (_media == null)
                _media = new Media(ref token);
            return _media;
        } }
        public Relationships Relationships { get {
            if (_relationships == null)
                _relationships = new Relationships(ref token);
            return _relationships; 
        } }
        public Comments Comments { get {
            if (_comments == null)
                _comments = new Comments(ref token);
            return _comments;
        } }
        public Likes Likes { get {
            if (_likes == null)
                _likes = new Likes(ref token);
            return _likes; 
        } }
        public Tags Tags { get {
            if (_tags == null)
                _tags = new Tags(ref token);
            return _tags; 
        } }
        public Locations Locations { get {
            if (_locations == null)
                _locations = new Locations(ref token);
            return _locations;
        } }
        public Geographies Geographies { get {
            if (_geo == null)
                _geo = new Geographies(ref token);
            return _geo;
        } }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
