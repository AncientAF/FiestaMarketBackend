using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommand : IRequest<UnitResult<Error>>
    {
        public Guid UserId { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
