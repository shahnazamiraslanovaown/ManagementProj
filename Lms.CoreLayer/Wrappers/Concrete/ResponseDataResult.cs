using Lms.CoreLayer.Enums;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.CoreLayer.Wrappers.Concrete;

public class ResponseDataResult<T> : ResponseResult, IResponseDataResult<T>
{
    public ICollection<ResponseValidationResult> ResponseValidationResults { get; set; } = new List<ResponseValidationResult>();
    public T Data { get; set; }
    public ResponseDataResult(ResponseType responseType) : base(responseType)
    {
    }

    public ResponseDataResult(ResponseType responseType, string message) : base(responseType, message)
    {
    }

    public ResponseDataResult(ResponseType responseType, T data) : base(responseType)
    {
        Data = data;
    }

    public ResponseDataResult(IList<ResponseValidationResult> validationResults) : base(ResponseType.ValidationError)
    {
        ResponseValidationResults = validationResults;
    }
    public ResponseDataResult(IList<ResponseValidationResult> validationResults, T data) : base(ResponseType.ValidationError)
    {
        Data = data;
        ResponseValidationResults = validationResults;
    }
  
}
