using FluentValidation;

namespace FiestaMarketBackend.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(3).WithMessage("Name length must be greater than 3").When(p => p.Name != null);

            RuleFor(p => p.FullName)
                .MinimumLength(3).WithMessage("FullName length must be greater than 3").When(p => p.FullName != null);

            RuleFor(p => p.MinQuantity)
                .GreaterThan(0).WithMessage("Min quantity must be greater than 0").When(p => p.MinQuantity != null);

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price quantity must be greater than 0").When(p => p.Price != null);
        }
    }
}
