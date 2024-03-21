using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommand>
    {
        private readonly UserRepository _userRepository;

        public AddToFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddProductsToFavoriteAsync(request.UserId, request.Products);

            return;
        }
    }
}
