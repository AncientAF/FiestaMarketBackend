using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, List<OrderResponse>>
    {
        private readonly UserRepository _userRepository;

        public GetUserOrdersQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<OrderResponse>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetOrdersAsync(request.Id);

            return result.Adapt<List<OrderResponse>>();
        }
    }
}
