using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly OrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetByIdAsync(request.Id);

            return result.Adapt<OrderResponse>();
        }
    }
}
