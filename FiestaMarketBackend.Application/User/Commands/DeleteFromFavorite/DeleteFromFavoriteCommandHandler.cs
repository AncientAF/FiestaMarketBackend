using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommandHandler : IRequestHandler<DeleteFromFavoriteCommand>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteFromFavoriteCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteProductsFromFavoriteAsync(request.UserId, request.ItemsId);

            return;
        }
    }
}
