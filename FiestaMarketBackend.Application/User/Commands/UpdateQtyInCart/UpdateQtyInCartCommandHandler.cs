using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommandHandler : IRequestHandler<UpdateQtyInCartCommand>
    {
        private readonly UserRepository _userRepository;

        public UpdateQtyInCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateQtyInCartCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateQtyInCartAsync(request.UserId, request.Items);

            return;
        }
    }
}
