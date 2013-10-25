using Instagram.Model;

namespace Instagram.Response
{
    public interface IResponse<T>
    {
        string accessToken { get; set; }
        RateLimit limit { get; set; }
        meta meta { get; set; }
        T data { get; set; }
        pagination pagination { get; set; }
    }
}
