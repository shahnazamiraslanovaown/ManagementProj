using Lms.CoreLayer.Wrappers.Concrete;

namespace Lms.CoreLayer.Wrappers.Interfaces;

public interface IResponseDataResult
{
    public interface IResponseDataResult<T> : IResponseResult
    {
        T Data { get; set; }
        ICollection<ResponseValidationResult> ResponseValidationResults { get; set; }
    }
}
