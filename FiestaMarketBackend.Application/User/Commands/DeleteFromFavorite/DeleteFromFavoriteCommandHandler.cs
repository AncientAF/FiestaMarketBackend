using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class DeleteFromFavoriteCommandHandler : IRequestHandler<DeleteFromFavoriteCommand, UnitResult<Error>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteFromFavoriteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteFromFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromFavoriteAsync(request.Id, request.Items);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
