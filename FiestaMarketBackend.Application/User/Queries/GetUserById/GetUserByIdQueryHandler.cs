using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public GetUserByIdQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse, Error>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<UserResponse, Error>(result.Error);

            return Result.Success<UserResponse, Error>(result.Value.Adapt<UserResponse>());
        }
    }
}
