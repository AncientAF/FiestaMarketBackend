using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Core.Entities;
    public class AddToCartCommand : IRequest<Result<CartResponse>>
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; }

    }
}
