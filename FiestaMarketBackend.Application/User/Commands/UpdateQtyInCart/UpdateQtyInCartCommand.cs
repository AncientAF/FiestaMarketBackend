using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommand : ICommand<Result<CartResponse, Error>>
    {
        public Guid UserId { get; set; }
        public required List<CartItem> Items { get; set; }
    }
}
