using Lms.CoreLayer.Enums;
using Lms.CoreLayer.Wrappers.Interfaces;

namespace Lms.CoreLayer.Wrappers.Concrete
{
    public class ResponseResult :  IResponseResult
    {
        public ResponseResult(ResponseType responseType) => ResponseType = responseType;

        public ResponseResult(
            ResponseType responseType,
            string message)
        {
            ResponseType = responseType;
            Message = message;
        }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
