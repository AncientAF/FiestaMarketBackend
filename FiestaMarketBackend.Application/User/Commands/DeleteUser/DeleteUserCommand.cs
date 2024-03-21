using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
