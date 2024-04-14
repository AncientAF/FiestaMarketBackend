using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand, UnitResult<Error>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteFromCartCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromCartAsync(request.Id, request.Items);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
