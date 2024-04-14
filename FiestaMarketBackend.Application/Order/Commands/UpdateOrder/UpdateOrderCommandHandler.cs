using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Order
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<OrderResponse, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<OrderResponse, Error>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user.IsFailure)
                return Result.Failure<OrderResponse, Error>(user.Error);

            order.User = user.Value;

            var result = await _orderRepository.UpdateAsync(order);

            if (result.IsFailure)
                return Result.Failure<OrderResponse, Error>(result.Error);

            return Result.Success<OrderResponse, Error>(result.Value.Adapt<OrderResponse>());
        }
    }
}
