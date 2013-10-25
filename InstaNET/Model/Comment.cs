namespace InstaNET.Model
{
    public class Comment
    {
        public string id { get; set; }
        public long created_time { get; set; }
        public string text { get; set; }
        public UserInfo from { get; set; }
    }
}
