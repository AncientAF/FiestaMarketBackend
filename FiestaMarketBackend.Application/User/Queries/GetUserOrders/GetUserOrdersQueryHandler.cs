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

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, Result<List<OrderResponse>, Error>>
    {
        private readonly UserRepository _userRepository;

        public GetUserOrdersQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<OrderResponse>, Error>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetOrdersAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<List<OrderResponse>, Error>(result.Error);

            return Result.Success<List<OrderResponse>, Error>(result.Value.Adapt<List<OrderResponse>>());
        }
    }
}
