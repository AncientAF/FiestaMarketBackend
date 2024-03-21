using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommand : IRequest
    {
        public Guid Id { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
