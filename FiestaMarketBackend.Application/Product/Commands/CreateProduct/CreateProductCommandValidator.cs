using FiestaMarketBackend.Core.Entities;
using FluentValidation;

namespace FiestaMarketBackend.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public ProductDescription? Description { get; set; }
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Enter name for product")
                .MinimumLength(3).WithMessage("Name length must be greater than 3");

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Enter FullName for product")
                .MinimumLength(3).WithMessage("FullName length must be greater than 3");

            RuleFor(p => p.MinQuantity)
                .NotEmpty().WithMessage("Enter MinQuantity for product")
                .GreaterThan(0).WithMessage("Min quantity must be greater than 0");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Enter Price for product")
                .GreaterThan(0).WithMessage("Price quantity must be greater than 0");
        }
    }
}
