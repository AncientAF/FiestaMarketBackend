using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Commands.UpdateQtyInCart
{
    public class UpdateQtyInCartCommandValidator : AbstractValidator<UpdateQtyInCartCommand>
    {
        public UpdateQtyInCartCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Items).NotEmpty().WithMessage("Nothing to delete");

            RuleForEach(f => f.Items).ChildRules(i =>
            {
                i.RuleFor(i => i.ProductId).NotEmpty().WithMessage("Product id can't be empty");
                i.RuleFor(i => i.Quantity).GreaterThan(-1).WithMessage("Quantity can't be negative");
                i.RuleFor(i => i.Price).GreaterThan(-1).WithMessage("Price can't be negative");
            });
        }
    }
}
