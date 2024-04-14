using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Application.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public FavoriteResponse? Favorite { get; set; }
        public CartResponse? Cart { get; set; }
        public List<OrderResponse>? Orders { get; set; }
        public List<UserRoleResponse> Roles { get; set; } = new();
    }

    public class UserRoleResponse
    {
        public required string Name { get; set; }
        public List<PermissionResponse> Permissions { get; set; } = new();
    }

    public class PermissionResponse
    {
        public required string Name { get; set; }
    }
}
