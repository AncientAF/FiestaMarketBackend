using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public required User User { get; set; }
        public OrderStatus Status { get; set; }
        public required Address Address { get; set; }
        public required List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
