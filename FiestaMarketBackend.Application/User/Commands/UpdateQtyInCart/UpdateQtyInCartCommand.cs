using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Application.User
{
    public class UpdateQtyInCartCommand : IInvalidateCacheCommand<Result<CartResponse, Error>>
    {
        public Guid Id { get; set; }
        public required List<CartItem> Items { get; set; }

        public string[] Keys => [$"user-by-id-{Id}"];
    }
}
