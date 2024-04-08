using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class DeleteOrderCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
