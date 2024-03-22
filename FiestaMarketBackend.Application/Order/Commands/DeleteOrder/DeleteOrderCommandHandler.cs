using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly OrderRepository _orderRepository;

        public DeleteOrderCommandHandler(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteAsync(request.Id);

            return;
        }
    }
}
