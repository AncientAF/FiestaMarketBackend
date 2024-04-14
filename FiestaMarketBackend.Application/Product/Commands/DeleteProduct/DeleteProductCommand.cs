using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product
{
    public class DeleteProductCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"product-by-id{Id}"];
    }
}
