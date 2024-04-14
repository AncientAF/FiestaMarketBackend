using FluentValidation;

namespace FiestaMarketBackend.Application.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email can't be empty").EmailAddress().WithMessage("Wrong format for email");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password can't be empty");
        }
    }
}
