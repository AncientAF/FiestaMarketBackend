using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class GetCategoryWithSubCategoriesQuery : IRequest<Result<List<CategoryResponse>>>
    {
    }
}
