namespace FiestaMarketBackend.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public Favorite? Favorite { get; set; }
        public Cart? Cart { get; set; }
        public List<Order>? Orders { get; set; }
        public required List<UserRole> Roles { get; set; }
    }
}
