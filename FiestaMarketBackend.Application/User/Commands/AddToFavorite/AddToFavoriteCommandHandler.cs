using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommand, FavoriteResponse>
    {
        private readonly UserRepository _userRepository;

        public AddToFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<FavoriteResponse> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = await _userRepository.AddProductsToFavoriteAsync(request.UserId, request.Products);

            return favorite.Adapt<FavoriteResponse>();
        }
    }
}
