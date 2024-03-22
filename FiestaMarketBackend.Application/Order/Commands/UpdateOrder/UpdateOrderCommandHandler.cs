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
    using FiestaMarketBackend.Core.Entities;
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly UserRepository _userRepository;
        private readonly OrderRepository _orderRepository;

        public UpdateOrderCommandHandler(OrderRepository orderRepository, UserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();

            var user = await _userRepository.GetByIdAsync(request.UserId);
            order.User = user;

            await _orderRepository.UpdateAsync(order);

            return;
        }
    }
}
