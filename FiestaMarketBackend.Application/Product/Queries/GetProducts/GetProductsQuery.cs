using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsQuery : ICommand<Result<List<ProductResponse>, Error>>
    {
    }
}
