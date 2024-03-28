using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
