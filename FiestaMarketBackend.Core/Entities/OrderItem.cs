namespace FiestaMarketBackend.Core.Entities
{
    public record OrderItem
    {
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}