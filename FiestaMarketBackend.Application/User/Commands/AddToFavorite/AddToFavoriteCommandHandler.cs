using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class AddToFavoriteCommandHandler : IRequestHandler<AddToFavoriteCommand, Result<FavoriteResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public AddToFavoriteCommandHandler(IUserRepository userRepository)
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
