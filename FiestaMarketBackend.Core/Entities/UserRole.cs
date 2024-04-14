namespace FiestaMarketBackend.Core.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Permission> Permissions { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
