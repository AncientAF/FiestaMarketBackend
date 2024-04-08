using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse, Error>>
    {
        private readonly OrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<OrderResponse, Error>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<OrderResponse, Error>(result.Error);

            return Result.Success<OrderResponse, Error>(result.Value.Adapt<OrderResponse>());
        }
    }
}
