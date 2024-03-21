using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Core.Entities;
    public class AddToFavoriteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
