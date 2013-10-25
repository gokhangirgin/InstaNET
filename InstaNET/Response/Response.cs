namespace InstaNET.Response
{
    class Response<T> : IResponse<T>
    {
        public RateLimit limit
        {
            get;
            set;
        }

        public Model.meta meta
        {
            get;
            set;
        }

        public T data
        {
            get;
            set;
        }

        public Model.pagination pagination
        {
            get;
            set;
        }
    }
}
