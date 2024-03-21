using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Core.Entities;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly UserRepository _userRepository;

        public CreateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.AddAsync(request.Adapt<User>());

            return;
        }
    }
}
