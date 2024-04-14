using FluentValidation;
using System.Text.RegularExpressions;

namespace FiestaMarketBackend.Application.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotNull().WithMessage("Enter Name")
                .MinimumLength(2).WithMessage("Name length must be greater than 2");

            RuleFor(u => u.SurName)
                .NotNull().WithMessage("Enter SurName")
                .MinimumLength(2).WithMessage("Surname length must be greater than 2");

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Incorrect email address");

            RuleFor(u => u.Password)
                .NotNull().WithMessage("Enter password")
                .MinimumLength(10).WithMessage("Password length must be greater than 10");

            RuleFor(u => u.PhoneNumber)
                .Must(IsPhoneNumber).WithMessage("Incorrect phone number");

            RuleForEach(u => u.Addresses).ChildRules(a =>
            {
                RuleFor(a => a.PhoneNumber)
                    .Must(IsPhoneNumber).WithMessage("Incorrect phone number").When(a => a.Addresses != null).OverridePropertyName("AddressPhoneNumber");
            });

            RuleFor(u => u.Roles).NotEmpty().WithMessage("User must have a role");
        }

        private bool IsPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null) return false;

            var pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
            var regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
    }
}
