using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product
{
    public class GetProductsQuery : IQuery<Result<List<ProductResponse>, Error>>
    {
    }
}
