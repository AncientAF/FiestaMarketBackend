using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommand : IRequest<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public List<Guid> ItemsId { get; set; }
    }
}
