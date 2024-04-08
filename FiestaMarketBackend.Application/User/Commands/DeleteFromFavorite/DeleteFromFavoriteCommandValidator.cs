using FluentValidation;

namespace FiestaMarketBackend.Application.User.Commands.DeleteFromFavorite
{
    public class DeleteFromFavoriteCommandValidator : AbstractValidator<DeleteFromFavoriteCommand>
    {
        public DeleteFromFavoriteCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Items).NotEmpty().WithMessage("Nothing to delete");

            RuleForEach(f => f.Items).NotNull().WithMessage("Null guid");
        }
    }
}
