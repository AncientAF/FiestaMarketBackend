using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order
{
    public class DeleteOrderCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"order-by-id{Id}"];
    }
}
