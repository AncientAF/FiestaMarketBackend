namespace FiestaMarketBackend.Core.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<UserRole> Roles { get; set; } = new();
    }
}