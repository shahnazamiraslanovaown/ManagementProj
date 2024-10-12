using AutoMapper;
using FluentValidation;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Validations;
using Lms.CoreLayer.Enums;
using Lms.CoreLayer.Extensions;
using Lms.CoreLayer.Helpers;
using Lms.CoreLayer.Wrappers.Concrete;
using Lms.CoreLayer.Wrappers.Interfaces;
using Lms.DataAccessLayer.Abstract;
using Lms.Entity.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Lms.CoreLayer.Wrappers.Interfaces.IResponseDataResult;

namespace Lms.BusinessLogic.Concrete;

public class UserService : IUserService
{

    private readonly IUserDetailRepository _userDetailRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreatUserDto> _createUserDtoValidator;
    private readonly IValidator<SigninUserDto> _signinUserDtoValidator;
    private readonly IMapper _mapper;
    private RegisterUserDto _registerUser;
    public UserService(IUserRepository userRepository,
                       IUserDetailRepository userDetailRepository,
                       IValidator<CreatUserDto> createUserDtoValidator,
                       IMapper mapper,
                       IValidator<SigninUserDto> signinUserDtoValidator)
    {
        _userRepository = userRepository;
        _userDetailRepository = userDetailRepository;
        _createUserDtoValidator = createUserDtoValidator;
        _mapper = mapper;
        _signinUserDtoValidator = signinUserDtoValidator;
    }


    public RegisterUserDto GetRegisterUserDto()
    {
        return _registerUser;
    }
    public async Task<IResponseResult> ChangeUserStatusAsync(RegisterStatusEnum registerStatus, int userId)
    {
        var user = await _userDetailRepository
             .GetWhereAsync(x => x.UserId == userId)
             .SingleOrDefaultAsync();

        if (user is not null)
        {
            user.StatusId = (int)registerStatus;
         
            return new ResponseResult(ResponseType.SuccessResult);
        }

        return new ResponseResult(ResponseType.NotFound);
    }

    public async Task<IResponseDataResult<bool>> CheckConfirmCodeAsync(int confirmCode, int userId)
    {
        var user = await _userDetailRepository
           .GetWhereAsync(x => x.UserId == userId && x.ConfirmCode == confirmCode)
           .FirstOrDefaultAsync();

        return new ResponseDataResult<bool>(ResponseType.SuccessResult, user != null);
    }

    public async Task<IResponseDataResult<RegisterUserDto>> CheckUserAsync(SigninUserDto userDto)
    {
        var result = await _signinUserDtoValidator.ValidateAsync(userDto);

        if (result.IsValid is false)
        {
            return new ResponseDataResult<RegisterUserDto>(result.ToResponseValidationResults());
        }

        var user = await _userRepository.GetSigninUserWithDetailAsync(userDto.Email);
        if (user is null)
        {
            return new ResponseDataResult<RegisterUserDto>(
                [new() { ErrorMessage = "User is not found by email", PropertyName = "Email" }]);
        }

        bool isCorrectPassword = HashHelper.VerifyPasswordHash(userDto.Password,
                                                               user.PassworHash.ToByte(),
                                                               user.PasswordSalt.ToByte());

        if (isCorrectPassword is false)
        {
            return new ResponseDataResult<RegisterUserDto>(
                [new() { ErrorMessage = "Password is incorrect", PropertyName = "Password" }]);
        }

        return new ResponseDataResult<RegisterUserDto>(ResponseType.SuccessResult, new RegisterUserDto()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.UserDetail.FirstName,
            LastName = user.UserDetail.LastName,
            ConfirmCode = user.UserDetail.ConfirmCode,
        });
    }


    public void SetRegisterUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier));
        var firstName = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name));
        var lastName = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Surname));

        _registerUser = new RegisterUserDto
        {
            Id = Convert.ToInt32(userId.Value),
            FirstName = firstName.Value.ToString(),
            LastName = lastName.Value,
        };

    }
    public async Task<IResponseDataResult.IResponseDataResult<RegisterUserDto>> CreateUser(CreatUserDto userDto)
    {
        var result = await _createUserDtoValidator.ValidateAsync(userDto);

        if (result.IsValid is false)
        {
            return new ResponseDataResult<RegisterUserDto>(result.ToResponseValidationResults());
        }

        var user = await _userRepository
            .GetWhereAsync(x => x.Email == userDto.Email)
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            return new ResponseDataResult<RegisterUserDto>([new() { ErrorMessage = "Mail is registered", PropertyName = "Email" }]);
        }


        var userEntity = _mapper.Map<User>(userDto);
        userEntity.UserDetail = _mapper.Map<UserDetail>(userDto);

        byte[] passwordHash;
        byte[] passwordSalt;

        HashHelper
            .CreatePasswordHash(userDto.Password,
                                out passwordHash,
                                out passwordSalt);

        userEntity.PassworHash = passwordHash.ByteToString();
        userEntity.PasswordSalt = passwordSalt.ByteToString();
        userEntity.UserDetail.ConfirmCode = CodeGenerator.GenerateConfirmCode();
        userEntity.UserDetail.StatusId = (int)RegisterStatusEnum.Register;
        userEntity.UserRoles =
        [
            new() {RoleId = 3}
        ];
        await _userRepository.AddAsync(userEntity);
        await _userRepository.SaveChangesAsync();

        return new ResponseDataResult<RegisterUserDto>(ResponseType.SuccessResult, new RegisterUserDto()
        {
            Id = userEntity.Id,
            Email = userEntity.Email,
            ConfirmCode = userEntity.UserDetail.ConfirmCode,
            FirstName = userEntity.UserDetail.FirstName,
            LastName = userEntity.UserDetail.LastName,
        });
    }
}
