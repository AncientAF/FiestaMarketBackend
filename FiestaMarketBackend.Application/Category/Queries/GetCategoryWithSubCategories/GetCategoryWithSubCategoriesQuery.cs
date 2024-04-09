using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Category
{
    public class GetCategoryWithSubCategoriesQuery : IQuery<Result<List<CategoryResponse>, Error>>
    {
    }
}
