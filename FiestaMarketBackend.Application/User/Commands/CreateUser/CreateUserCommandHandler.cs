using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid, Error>>
    {
        private readonly UserRepository _userRepository;

        public CreateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid, Error>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddAsync(request.Adapt<User>());

            if (result.IsFailure)
                return Result.Failure<Guid, Error>(result.Error);

            return Result.Success<Guid, Error>(result.Value);
        }
    }
}
