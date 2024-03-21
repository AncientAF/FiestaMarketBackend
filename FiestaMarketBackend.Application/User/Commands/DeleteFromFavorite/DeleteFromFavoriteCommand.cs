using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
