using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteUserCommand : IRequest<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
