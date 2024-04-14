using FluentValidation;

namespace FiestaMarketBackend.Application.User
{
    public class AddToFavoriteCommandValidator : AbstractValidator<AddToFavoriteCommand>
    {
        public AddToFavoriteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Products)
                .NotEmpty().WithMessage("Nothing to add");

            RuleForEach(f => f.Products)
                .NotNull().WithMessage("Null guid");
        }
    }
}
