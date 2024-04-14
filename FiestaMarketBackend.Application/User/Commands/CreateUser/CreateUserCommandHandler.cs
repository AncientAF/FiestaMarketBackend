using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Authentication;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<Guid, Error>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _passwordHasher.Generate(request.Password);

            var result = await _userRepository.AddAsync(request.Adapt<User>(), request.Roles);

            if (result.IsFailure)
                return Result.Failure<Guid, Error>(result.Error);

            return Result.Success<Guid, Error>(result.Value);
        }
    }
}
