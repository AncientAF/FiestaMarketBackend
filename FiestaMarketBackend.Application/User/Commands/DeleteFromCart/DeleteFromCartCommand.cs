using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
