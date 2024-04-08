using FluentValidation;

namespace FiestaMarketBackend.Application.User.Commands.AddToCart
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        public AddToCartCommandValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("User id can't be empty");

            RuleFor(c => c.Items)
                .NotEmpty().WithMessage("Specify items to add");

            RuleForEach(c => c.Items).ChildRules(i =>
            {
                i.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Null product id");
                i.RuleFor(i => i.Quantity).GreaterThan(1).WithMessage("Quantity of item should be greater than 1");
                i.RuleFor(i => i.Price).GreaterThan(0).WithMessage("Price can't be negative");
            });
        }
    }
}
