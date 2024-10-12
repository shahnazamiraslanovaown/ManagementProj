﻿using FluentValidation;
using Lms.BusinessLogic.Dtos;

namespace Lms.BusinessLogic.Validations
{
    public class SigninUserDtoValidator : AbstractValidator<SigninUserDto>
    {
        public SigninUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is incorrect format")
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
