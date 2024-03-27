using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    public class AddToFavoriteCommand : IRequest<FavoriteResponse>
    {
        public Guid UserId { get; set; }
        public List<Guid> Products { get; set; }
    }
}
