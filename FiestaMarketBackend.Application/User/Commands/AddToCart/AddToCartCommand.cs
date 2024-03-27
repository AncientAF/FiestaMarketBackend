using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToCartCommand : IRequest<CartResponse>
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; }

        public class CartItem
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }


}
