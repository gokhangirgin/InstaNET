using InstaNET.Model;

namespace InstaNET.Response
{
    public interface IResponse<T>
    {
        RateLimit limit { get; set; }
        meta meta { get; set; }
        T data { get; set; }
        pagination pagination { get; set; }
    }
}
