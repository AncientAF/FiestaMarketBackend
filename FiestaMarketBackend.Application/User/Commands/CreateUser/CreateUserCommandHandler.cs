using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using FiestaMarketBackend.Core.Entities;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly UserRepository _userRepository;

        public CreateUserCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var id = await _userRepository.AddAsync(request.Adapt<User>());

            return id;
        }
    }
}
