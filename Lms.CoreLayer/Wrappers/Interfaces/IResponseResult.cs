using Lms.CoreLayer.Enums;

namespace Lms.CoreLayer.Wrappers.Interfaces;

public interface IResponseResult
{
    string Message { get; set; }
    ResponseType ResponseType { get; set; }
}
