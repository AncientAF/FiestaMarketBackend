using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;


    public class AddToCartCommand : ICommand<Result<CartResponse, Error>>
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; } = new();
    }
}
