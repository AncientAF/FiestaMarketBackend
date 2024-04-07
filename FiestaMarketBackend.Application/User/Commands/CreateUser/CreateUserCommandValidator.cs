﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name).MinimumLength(2).WithMessage("Name length must be greater than 2");

            RuleFor(u => u.SurName).MinimumLength(2).WithMessage("Surname length must be greater than 2");

            RuleFor(u => u.Email).EmailAddress().WithMessage("Incorrect email address");

            RuleFor(u => u.Password).MinimumLength(10).WithMessage("Password length must be greater than 10");

            RuleFor(u => u.PhoneNumber).Must(IsPhoneNumber).WithMessage("Incorrect phone number");

            RuleForEach(u => u.Addresses).ChildRules(a =>
            {
                RuleFor(a => a.PhoneNumber).Must(IsPhoneNumber).WithMessage("Incorrect phone number");
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