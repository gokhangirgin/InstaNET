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
        public TokenManager Token { get { return token; } }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
