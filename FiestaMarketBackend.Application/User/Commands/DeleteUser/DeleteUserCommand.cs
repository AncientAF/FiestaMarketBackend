using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteUserCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
