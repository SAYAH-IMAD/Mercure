namespace Mercure.Common.Response
{
    public class Response
    {
        public Error[] Errors { get; set; }
        public bool IsSucces { get; set; }
        public object Result { get; set; }

        public Response() { }
        public Response(object result, 
            bool isSucces = true, 
            Error[] errors = null)
        {
            Result = result;
            IsSucces = isSucces;
            Errors = errors;
        }

    }
}
