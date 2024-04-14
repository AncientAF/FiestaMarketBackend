using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserResponse>, Error>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserResponse>, Error>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAsync();

            if (result.IsFailure)
                return Result.Failure<List<UserResponse>, Error>(result.Error);

            return Result.Success<List<UserResponse>, Error>(result.Value.Adapt<List<UserResponse>>());
        }
    }
}
