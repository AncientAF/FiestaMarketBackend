using FluentValidation;

namespace FiestaMarketBackend.Application.Product.Queries.GetProductsByPage
{
    public class GetProductsByPageQueryValidator : AbstractValidator<GetProductsByPageQuery>
    {
        public GetProductsByPageQueryValidator()
        {
            RuleFor(p => p.PageIndex).GreaterThan(0).WithMessage("Page index must be greater than 0");

            RuleFor(p => p.PageSize).GreaterThan(0).WithMessage("Page size must be greater than 0");
        }
    }
}
