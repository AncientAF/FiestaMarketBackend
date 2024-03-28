using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
