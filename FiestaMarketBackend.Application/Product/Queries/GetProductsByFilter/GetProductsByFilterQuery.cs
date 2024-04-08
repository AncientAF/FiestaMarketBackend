using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsByFilterQuery : ICommand<Result<List<ProductResponse>, Error>>
    {
        public string? Name { get; set; }
        public Guid? Category { get; set; }
    }
}
