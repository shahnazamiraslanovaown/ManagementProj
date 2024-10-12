using FluentValidation;
using Lms.BusinessLogic.Dtos;

namespace Lms.BusinessLogic.Validations
{
    public class CreateUserDtoValidator : AbstractValidator<CreatUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is incorrect format");

            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
        }
    }
}
