using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UnitResult<Error>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteAsync(request.Id);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
