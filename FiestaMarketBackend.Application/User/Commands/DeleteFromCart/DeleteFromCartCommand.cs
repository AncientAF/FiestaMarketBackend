using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommand : ICommand<UnitResult<Error>>
    {
        public Guid UserId { get; set; }
        public required List<Guid> Items { get; set; }
    }
}
