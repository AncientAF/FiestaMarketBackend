using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User
{
    public class GetCartQuery : IQuery<Result<CartResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
