using FluentValidation;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(n => n.Id).NotEmpty().WithMessage("Id can't be empty");

            RuleFor(n => n.Name).NotEmpty().WithMessage("Name can't be empty");

            RuleFor(n => n.ShortDescription).NotEmpty().WithMessage("Short description can't be empty");

            RuleFor(n => n.DescriptionMarkDown).NotEmpty().WithMessage("Description can't be empty");
        }
    }
}
