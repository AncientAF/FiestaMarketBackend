using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core.Entities;
    using Mapster;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;

        public CreateOrderCommandHandler(OrderRepository orderRepository, UserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user.IsFailure)
                return Result.Failure<Guid>(user.Error);

            order.User = user.Value;

            var result = await _orderRepository.AddAsync(order);

            if(result.IsFailure)
                return Result.Failure<Guid>(result.Error);

            return Result.Success(result.Value);
        }
    }
}
