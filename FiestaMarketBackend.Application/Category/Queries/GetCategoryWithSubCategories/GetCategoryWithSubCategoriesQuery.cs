using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class GetCategoryWithSubCategoriesQuery : ICommand<Result<List<CategoryResponse>, Error>>
    {
    }
}
