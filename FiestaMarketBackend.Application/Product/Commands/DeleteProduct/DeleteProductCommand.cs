using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"product-by-id{Id}"];
    }
}
