using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand, UnitResult<Error>>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromCartAsync(request.UserId, request.Items);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
