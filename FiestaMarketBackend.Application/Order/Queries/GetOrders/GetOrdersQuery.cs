using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrdersQuery : IQuery<Result<List<OrderResponse>, Error>>
    {

    }
}
