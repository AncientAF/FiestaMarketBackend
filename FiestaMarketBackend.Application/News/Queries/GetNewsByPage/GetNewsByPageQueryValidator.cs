using FluentValidation;

namespace FiestaMarketBackend.Application.News.Queries.GetNewsByPage
{
    public class GetNewsByPageQueryValidator : AbstractValidator<GetNewsByPageQuery>
    {
        public GetNewsByPageQueryValidator()
        {
            RuleFor(p => p.PageIndex).GreaterThan(0).WithMessage("Page index must be greater than 0");

            RuleFor(p => p.PageSize).GreaterThan(0).WithMessage("Page size must be greater than 0");
        }
    }
}
