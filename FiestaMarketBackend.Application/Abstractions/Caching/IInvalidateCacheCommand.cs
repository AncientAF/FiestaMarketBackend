using FiestaMarketBackend.Application.Abstractions.Messaging;

namespace FiestaMarketBackend.Application.Abstractions.Caching
{
    public interface IInvalidateCacheCommand
    {
        string[] Keys { get; }
    }

    public interface IInvalidateCacheCommand<TResponse> : ICommand<TResponse>, IInvalidateCacheCommand;
}
