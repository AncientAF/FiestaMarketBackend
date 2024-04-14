using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, Result<List<OrderResponse>, Error>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserOrdersQueryHandler(IUserRepository userRepository)
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
