using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrderByIdQuery : ICachedQuery<Result<OrderResponse, Error>>
    {
        public Guid Id { get; set; }

        public string Key => $"order-by-id{Id}";

        public TimeSpan? Expiration => default;
    }
}
