using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<OrderResponse, Error>>
    {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;

        public UpdateOrderCommandHandler(OrderRepository orderRepository, UserRepository userRepository)
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
