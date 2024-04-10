using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Application.Abstractions.Caching;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;


    public class AddToCartCommand : IInvalidateCacheCommand<Result<CartResponse, Error>>
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public string[] Keys => [$"user-by-id-{Id}"];
    }
}
