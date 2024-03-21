using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Application.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public FavoriteResponse? Favorite { get; set; }
        public CartResponse? Cart { get; set; }
        public List<OrderResponse>? Orders { get; set; }
    }
}
