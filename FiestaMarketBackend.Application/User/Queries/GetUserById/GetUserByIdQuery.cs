using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetUserByIdQuery : ICachedQuery<Result<UserResponse, Error>>
    {
        public Guid Id { get; set; }

        public string Key => $"user-by-id-{Id}";

        public TimeSpan? Expiration => null;
    }
}
