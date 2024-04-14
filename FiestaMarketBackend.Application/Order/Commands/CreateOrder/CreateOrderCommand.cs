using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Application.Order
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class CreateOrderCommand : ICommand<Result<Guid, Error>>
    {
        public Guid UserId { get; set; }
        public OrderStatus Status { get; set; }
        public required Address Address { get; set; }
        public required List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
