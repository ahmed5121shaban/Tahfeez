using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tahfeez.Application.Features.User.DTOs;

namespace Tahfeez.Application.Features.User.Validators.Update
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(u => u.userName).MinimumLength(3);
            RuleFor(u => u.email).EmailAddress();
            RuleFor(u => u.role).IsInEnum();
        }
    }
}
