namespace FiestaMarketBackend.Core.Entities
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Product>? Products { get; set; }
    }
}
