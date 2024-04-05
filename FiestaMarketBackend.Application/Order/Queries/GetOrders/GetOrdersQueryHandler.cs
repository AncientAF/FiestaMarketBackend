using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<List<OrderResponse>, Error>>
    {
        private readonly OrderRepository _orderRepository;

        public GetOrdersQueryHandler(OrderRepository orderRepository)
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
