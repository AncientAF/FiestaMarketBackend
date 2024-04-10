using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductByIdQuery : ICachedQuery<Result<ProductResponse, Error>>
    {
        public Guid Id { get; set; }

        public string Key => $"product-by-id{Id}";

        public TimeSpan? Expiration => default;
    }
}
