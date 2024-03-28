using CSharpFunctionalExtensions;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommandHandler : IRequestHandler<DeleteFromFavoriteCommand, Result>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(DeleteFromFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromFavoriteAsync(request.UserId, request.ItemsId);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }
    }
}
