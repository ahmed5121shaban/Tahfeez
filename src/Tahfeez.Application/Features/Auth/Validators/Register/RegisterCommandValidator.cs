using FluentValidation;
using System.Text.RegularExpressions;
using Tahfeez.Application.Features.Auth.Commands.Register;
using Tahfeez.Domain.Entities.Roles;

namespace Tahfeez.Application.Features.Auth.Validators.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(c => c.UserName).MinimumLength(3).NotEmpty().NotNull();
            RuleFor(c => c.Password).Must(PasswordValidator).NotEmpty().NotNull();
            RuleFor(c => c.ConfirmPassword).Equal(c=>c.Password);
            RuleFor(c => c.Role).NotEmpty().NotNull();
        }
        private bool PasswordValidator(string password)
        {
            var regex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            return Regex.IsMatch(password, regex);
        }
    }
}
