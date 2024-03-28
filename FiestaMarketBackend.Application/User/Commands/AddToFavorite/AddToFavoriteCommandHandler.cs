using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommand, Result<FavoriteResponse>>
    {
        private readonly UserRepository _userRepository;

        public AddToFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<FavoriteResponse>> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddProductsToFavoriteAsync(request.UserId, request.Products);

            if (result.IsFailure)
                return Result.Failure<FavoriteResponse>(result.Error);

            return Result.Success(result.Value.Adapt<FavoriteResponse>());
        }
    }
}
