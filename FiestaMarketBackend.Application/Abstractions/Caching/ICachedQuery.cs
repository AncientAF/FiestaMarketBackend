using FiestaMarketBackend.Application.Abstractions.Messaging;

namespace FiestaMarketBackend.Application.Abstractions.Caching
{
    public interface ICachedQuery
    {
        string Key { get; }
        TimeSpan? Expiration { get; }
    }

    public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;
}
