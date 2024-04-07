namespace FiestaMarketBackend.Core.Entities
{
    public class CartItem
    {
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}