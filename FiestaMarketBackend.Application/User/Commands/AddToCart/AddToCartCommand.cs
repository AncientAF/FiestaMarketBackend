using FiestaMarketBackend.Core.Entities;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToCartCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
