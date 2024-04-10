using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class DeleteOrderCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"order-by-id{Id}"];
    }
}
