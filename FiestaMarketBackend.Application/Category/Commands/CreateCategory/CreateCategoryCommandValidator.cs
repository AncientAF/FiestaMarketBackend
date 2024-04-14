using FluentValidation;

namespace FiestaMarketBackend.Application.Category.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can't be empty");
        }
    }
}
