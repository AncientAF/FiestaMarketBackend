using FluentValidation;

namespace FiestaMarketBackend.Application.News
{
    public class GetNewsByPageQueryValidator : AbstractValidator<GetNewsByPageQuery>
    {
        public GetNewsByPageQueryValidator()
        {
            RuleFor(p => p.PageIndex)
                .NotEmpty().WithMessage("Enter PageIndex")
                .GreaterThan(0).WithMessage("Page index must be greater than 0");

            RuleFor(p => p.PageSize)
                .NotEmpty().WithMessage("Enter PageSize")
                .GreaterThan(0).WithMessage("Page size must be greater than 0");
        }
    }
}
