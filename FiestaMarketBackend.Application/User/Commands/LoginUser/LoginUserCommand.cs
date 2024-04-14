using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User
{
    public class LoginUserCommand : ICommand<Result<string, Error>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
