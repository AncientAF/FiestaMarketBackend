using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Application.Order
{
    public class UpdateOrderCommand : IInvalidateCacheCommand<Result<OrderResponse, Error>>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public OrderStatus? Status { get; set; }
        public Address? Address { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal? TotalPrice { get; set; }
        public string[] Keys => [$"order-by-id{Id}"];
    }
}
