using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, Result<FavoriteResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public GetFavoritesQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<FavoriteResponse, Error>> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetFavoriteAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<FavoriteResponse, Error>(result.Error);

            return Result.Success<FavoriteResponse, Error>(result.Value.Adapt<FavoriteResponse>());
        }
    }
}
