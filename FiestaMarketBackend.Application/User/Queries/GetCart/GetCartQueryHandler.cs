using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Result<CartResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public GetCartQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse, Error>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetCartAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<CartResponse, Error>(result.Error);

            return Result.Success<CartResponse, Error>(result.Value.Adapt<CartResponse>());
        }
    }
}
