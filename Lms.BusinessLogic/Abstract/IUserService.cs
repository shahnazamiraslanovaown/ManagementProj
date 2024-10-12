using Lms.BusinessLogic.Dtos;
using Lms.CoreLayer.Enums;
using Lms.CoreLayer.Wrappers.Interfaces;
using Lms.Entity.Accounts;
using System.Security.Claims;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Abstract;

public interface IUserService
{
    Task<IResponseDataResult<RegisterUserDto>> CreateUser(CreatUserDto userDto);
    Task<IResponseResult> ChangeUserStatusAsync(RegisterStatusEnum registerStatus , int userId);
    Task<IResponseDataResult<bool>> CheckConfirmCodeAsync(int confirmCode, int userId);
    Task<IResponseDataResult<RegisterUserDto>> CheckUserAsync(SigninUserDto userDto);
    void SetRegisterUser(ClaimsPrincipal claimsPrincipal);
    RegisterUserDto GetRegisterUserDto();
}
