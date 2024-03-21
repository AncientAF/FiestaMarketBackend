using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    internal class AddToCartCommandHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly UserRepository _userRepository;

        public AddToCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddProductsToCartAsync(request.UserId, request.Items);

            return;
        }
    }
}
