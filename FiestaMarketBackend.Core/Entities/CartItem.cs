namespace FiestaMarketBackend.Core.Entities
{
    public record CartItem
    {
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}