using FluentValidation;

namespace FiestaMarketBackend.Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.UserId).NotEmpty().WithMessage("User id can't be empty");

            RuleFor(o => o.Id).NotEmpty().WithMessage("Order id can't be empty");

            RuleForEach(o => o.Items).ChildRules(i =>
            {
                i.RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price can't be negative or zero");
                i.RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Quantity can't be negative or zero");
                i.RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product Id can't be empty");
            });

            RuleFor(o => o.TotalPrice).GreaterThan(0).WithMessage("Total price can't be negative or zero");
        }
    }
}
