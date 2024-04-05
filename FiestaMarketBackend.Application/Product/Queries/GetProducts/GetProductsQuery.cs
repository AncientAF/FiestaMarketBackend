using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsQuery : IRequest<Result<List<ProductResponse>, Error>>
    {
    }
}
