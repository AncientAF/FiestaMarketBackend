using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommand : IRequest<Result<CartResponse, Error>>
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
