namespace FiestaMarketBackend.Application.User
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Caching;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    public class AddToFavoriteCommand : IInvalidateCacheCommand<Result<FavoriteResponse, Error>>
    {
        public Guid Id { get; set; }
        public required List<Guid> Products { get; set; }

        public string[] Keys => [$"user-by-id-{Id}"];
    }
}
