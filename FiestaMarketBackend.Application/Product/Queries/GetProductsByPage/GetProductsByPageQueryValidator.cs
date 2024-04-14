using FluentValidation;

namespace FiestaMarketBackend.Application.Product
{
    public class GetProductsByPageQueryValidator : AbstractValidator<GetProductsByPageQuery>
    {
        public GetProductsByPageQueryValidator()
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
