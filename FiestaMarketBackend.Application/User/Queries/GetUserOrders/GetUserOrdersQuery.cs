using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetUserOrdersQuery : IQuery<Result<List<OrderResponse>, Error>>
    {
        public Guid Id { get; set; }
    }
}
