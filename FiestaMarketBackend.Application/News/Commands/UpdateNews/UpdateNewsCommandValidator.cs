using FluentValidation;

namespace FiestaMarketBackend.Application.News
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(n => n.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
