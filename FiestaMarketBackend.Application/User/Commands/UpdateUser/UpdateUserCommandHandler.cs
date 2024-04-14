using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse, Error>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.UpdateAsync(request.Adapt<User>());

            if (result.IsFailure)
                return Result.Failure<UserResponse, Error>(result.Error);

            return Result.Success<UserResponse, Error>(result.Value.Adapt<UserResponse>());
        }
    }
}
