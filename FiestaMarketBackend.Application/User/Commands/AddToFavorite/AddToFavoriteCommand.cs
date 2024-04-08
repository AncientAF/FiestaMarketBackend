namespace FiestaMarketBackend.Application.User.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    public class AddToFavoriteCommand : ICommand<Result<FavoriteResponse, Error>>
    {
        public Guid UserId { get; set; }
        public required List<Guid> Products { get; set; }
    }
}
