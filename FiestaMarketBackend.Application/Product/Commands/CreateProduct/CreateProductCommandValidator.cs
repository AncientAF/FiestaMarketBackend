using FiestaMarketBackend.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public ProductDescription? Description { get; set; }
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Name length must be greater than 3");

            RuleFor(p => p.FullName).MinimumLength(3).WithMessage("FullName length must be greater than 3");

            RuleFor(p => p.MinQuantity).GreaterThan(0).WithMessage("Min quantity must be greater than 0");

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price quantity must be greater than 0");
        }
    }
}
