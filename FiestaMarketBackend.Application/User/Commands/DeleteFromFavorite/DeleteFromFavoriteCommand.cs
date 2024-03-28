using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
