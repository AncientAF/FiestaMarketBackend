using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsQuery : IRequest<Result<List<ProductResponse>>>
    {
    }
}
