using MediatR;

namespace FiestaMarketBackend.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>;
}
