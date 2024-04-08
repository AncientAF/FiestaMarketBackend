namespace FiestaMarketBackend.Application.Responses
{
    public record CartResponse
    {
        public Guid Id { get; set; }
        public List<CartItemResponse>? Items { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
