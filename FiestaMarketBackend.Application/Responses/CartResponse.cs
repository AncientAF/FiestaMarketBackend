namespace FiestaMarketBackend.Application.Responses
{
    public record CartResponse
    {
        public required ProductResponse Product { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}
