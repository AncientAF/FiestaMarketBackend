using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Order
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse, Error>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
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
