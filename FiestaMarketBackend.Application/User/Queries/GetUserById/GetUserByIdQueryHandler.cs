using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
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
