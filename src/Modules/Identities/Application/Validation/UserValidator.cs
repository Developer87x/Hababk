using FluentValidation;
using Hababk.Modules.Identities.Application.Models;

namespace Hababk.Modules.Identities.Application.Validation
{
    public class UserValidator :AbstractValidator<LoginDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}