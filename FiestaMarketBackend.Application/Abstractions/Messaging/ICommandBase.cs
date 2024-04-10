using MediatR;

namespace FiestaMarketBackend.Application.Abstractions.Messaging
{
    public interface ICommand<TResponse> : IRequest<TResponse>;
}
