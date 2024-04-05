using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class AddToFavoriteCommand : IRequest<Result<FavoriteResponse, Error>>
    {
        public Guid UserId { get; set; }
        public List<Guid> Products { get; set; }
    }
}
