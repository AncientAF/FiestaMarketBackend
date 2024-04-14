using FluentValidation;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteFromFavoriteCommandValidator : AbstractValidator<DeleteFromFavoriteCommand>
    {
        public DeleteFromFavoriteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Items)
                .NotEmpty().WithMessage("No items to delete specified");

            RuleForEach(f => f.Items)
                .NotNull().WithMessage("Null guid");
        }
    }
}
