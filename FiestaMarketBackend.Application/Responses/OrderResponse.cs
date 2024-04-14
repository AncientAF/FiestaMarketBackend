using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Application.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public required Address Address { get; set; }
        public required List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
