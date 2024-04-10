using FluentValidation;

namespace FiestaMarketBackend.Application.User.Commands.DeleteFromCart
{
    public class DeleteFromCartCommandValidator : AbstractValidator<DeleteFromCartCommand>
    {
        public DeleteFromCartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("User id can't be empty");

            RuleFor(f => f.Items)
                .NotEmpty().WithMessage("Nothing to delete");

            RuleForEach(f => f.Items)
                .NotNull().WithMessage("Null guid");
        }
    }
}
