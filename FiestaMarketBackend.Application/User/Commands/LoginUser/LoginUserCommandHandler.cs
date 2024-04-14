using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Authentication;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string, Error>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByEmail(request.Email);

            if (result.IsFailure)
                return Result.Failure<string, Error>(result.Error);

            if (!_passwordHasher.Verify(request.Password, result.Value.Password))
                return Result.Failure<string, Error>(Error.Validation("LoginUser", "Wrong password"));

            var token = _jwtProvider.GenerateToken(result.Value);

            return Result.Success<string, Error>(token);
        }
    }
}
