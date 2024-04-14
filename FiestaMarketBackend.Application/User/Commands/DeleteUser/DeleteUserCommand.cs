using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteUserCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }

        public string[] Keys => [$"user-by-id-{Id}"];
    }
}
