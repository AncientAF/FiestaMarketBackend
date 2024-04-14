using FluentValidation;

namespace FiestaMarketBackend.Application.User
{
    public class UpdateQtyInCartCommandValidator : AbstractValidator<UpdateQtyInCartCommand>
    {
        public UpdateQtyInCartCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Items).NotEmpty().WithMessage("Nothing to delete");

            RuleForEach(f => f.Items).ChildRules(i =>
            {
                i.RuleFor(i => i.ProductId)
                    .NotEmpty().WithMessage("Product id can't be empty");

                i.RuleFor(i => i.Quantity)
                    .NotEmpty().WithMessage("Enter quantity")
                    .GreaterThan(-1).WithMessage("Quantity can't be negative");

                i.RuleFor(i => i.Price)
                    .NotEmpty().WithMessage("Enter price")
                    .GreaterThan(-1).WithMessage("Price can't be negative");
            });
        }
    }
}
