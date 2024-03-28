using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserResponse>>
    {
        private readonly UserRepository _userRepository;

        public UpdateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.UpdateAsync(request.Adapt<User>());

            if (result.IsFailure)
                return Result.Failure<UserResponse>(result.Error);

            return Result.Success(result.Value.Adapt<UserResponse>());
        }
    }
}
