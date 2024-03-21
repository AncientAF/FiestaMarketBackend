using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
