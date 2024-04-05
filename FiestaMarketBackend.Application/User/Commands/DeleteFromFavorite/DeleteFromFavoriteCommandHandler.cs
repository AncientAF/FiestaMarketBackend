using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommandHandler : IRequestHandler<DeleteFromFavoriteCommand, UnitResult<Error>>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteFromFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromFavoriteAsync(request.UserId, request.ItemsId);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
