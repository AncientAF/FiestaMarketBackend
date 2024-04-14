using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Order
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<List<OrderResponse>, Error>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<OrderResponse>, Error>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetAsync();

            if (result.IsFailure)
                return Result.Failure<List<OrderResponse>, Error>(result.Error);

            return Result.Success<List<OrderResponse>, Error>(result.Value.Adapt<List<OrderResponse>>());
        }
    }
}
