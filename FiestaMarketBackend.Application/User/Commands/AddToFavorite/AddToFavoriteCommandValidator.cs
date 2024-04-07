using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Commands.AddToFavorite
{
    public class AddToFavoriteCommandValidator : AbstractValidator<AddToFavoriteCommand>
    {
        public AddToFavoriteCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Products).NotEmpty().WithMessage("Nothing to add");

            RuleForEach(f => f.Products).NotNull().WithMessage("Null guid");
        }
    }
}
