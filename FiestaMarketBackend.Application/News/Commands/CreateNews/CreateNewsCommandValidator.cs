﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("Name can't be empty");

            RuleFor(n => n.ShortDescription).NotEmpty().WithMessage("Short description can't be empty");

            RuleFor(n => n.DescriptionMarkDown).NotEmpty().WithMessage("Description can't be empty");
        }
    }
}