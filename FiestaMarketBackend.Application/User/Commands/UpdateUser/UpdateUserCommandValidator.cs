using FluentValidation;
using System.Text.RegularExpressions;

namespace FiestaMarketBackend.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Name)
                .MinimumLength(2).WithMessage("Name length must be greater than 2").When(u => u.Name is not null);

            RuleFor(u => u.SurName)
                .MinimumLength(2).WithMessage("Surname length must be greater than 2").When(u => u.SurName is not null);

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Incorrect email address").When(u => u.Email is not null);

            RuleFor(u => u.Password)
                .MinimumLength(10).WithMessage("Password length must be greater than 10").When(u => u.Password is not null);

            RuleFor(u => u.PhoneNumber)
                .Must(IsPhoneNumber!).WithMessage("Incorrect phone number").When(u => u.PhoneNumber is not null);

            RuleForEach(u => u.Addresses).ChildRules(a =>
            {
                RuleFor(a => a.PhoneNumber)
                    .Must(IsPhoneNumber!).OverridePropertyName("AddressPhoneNumber").WithMessage("Incorrect phone number").When(a => a.Addresses != null);
            });
        }

        private bool IsPhoneNumber(string phoneNumber)
        {
            var pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
            var regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
    }
}
