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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderResponse>>
    {
        private readonly OrderRepository _orderRepository;

        public GetOrdersQueryHandler(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetAsync();

            return result.Adapt<List<OrderResponse>>();
        }
    }
}
