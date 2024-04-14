namespace FiestaMarketBackend.Infrastructure.Authentication
{
    public class AuthOptions
    {
        public required RolePermissions[] RolePermissions { get; set; }
    }

    public class RolePermissions
    {
        public required string Role { get; set; }
        public required string[] Permissions { get; set; }
    }
}
