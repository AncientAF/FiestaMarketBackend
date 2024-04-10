using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommand, Result<FavoriteResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public AddToFavoriteCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<FavoriteResponse, Error>> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddProductsToFavoriteAsync(request.Id, request.Products);

            if (result.IsFailure)
                return Result.Failure<FavoriteResponse, Error>(result.Error);

            return Result.Success<FavoriteResponse, Error>(result.Value.Adapt<FavoriteResponse>());
        }
    }
}
