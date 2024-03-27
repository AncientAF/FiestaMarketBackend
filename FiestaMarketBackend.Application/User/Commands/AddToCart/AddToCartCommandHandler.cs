using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    internal class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, CartResponse>
    {
        private readonly UserRepository _userRepository;

        public AddToCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CartResponse> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _userRepository.AddProductsToCartAsync(request.UserId, request.Items.Adapt<List<CartItem>>());

            return cart.Adapt<CartResponse>();
        }
    }
}
