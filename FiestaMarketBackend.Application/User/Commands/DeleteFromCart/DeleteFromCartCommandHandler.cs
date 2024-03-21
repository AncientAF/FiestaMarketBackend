using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteProductsFromCartAsync(request.Id, request.ItemsId);

            return;
        }
    }
}
