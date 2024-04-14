using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteFromFavoriteCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public required List<Guid> Items { get; set; }
        public string[] Keys => [$"user-by-id-{Id}"];
    }
}
