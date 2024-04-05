using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class GetCategoryWithSubCategoriesQuery : IRequest<Result<List<CategoryResponse>, Error>>
    {
    }
}
