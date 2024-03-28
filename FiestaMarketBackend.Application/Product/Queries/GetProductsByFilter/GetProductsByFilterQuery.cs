using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsByFilterQuery : IRequest<Result<List<ProductResponse>>>
    {
        public string? Name { get; set; }
        public Guid? Category { get; set; }

    }
}
