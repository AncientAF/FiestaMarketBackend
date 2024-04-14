using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Result<CartResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public GetCartQueryHandler(IUserRepository userRepository)
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
