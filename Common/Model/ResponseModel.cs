using System.Net;

namespace Common.Model
{
    public class BaseResponseModel
    {
        public BaseResponseModel(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; }

        public string Message { get; }
    }

    public class ResponseModel<T> : BaseResponseModel
    {
        public T Data { get; }

        public ResponseModel(T data) : base(HttpStatusCode.OK, string.Empty)
        {
            Data = data;
        }

        public ResponseModel(HttpStatusCode statusCode, string message, T data) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
