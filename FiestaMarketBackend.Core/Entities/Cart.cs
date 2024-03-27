namespace FiestaMarketBackend.Core.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<CartItem>? Items { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
