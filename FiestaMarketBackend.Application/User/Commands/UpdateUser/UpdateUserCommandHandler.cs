using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Core.Entities;
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserRepository _userRepository;

        public UpdateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateAsync(request.Adapt<User>());

            return;
        }
    }
}
