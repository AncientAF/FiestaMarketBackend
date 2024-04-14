namespace FiestaMarketBackend.Core.Entities
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}