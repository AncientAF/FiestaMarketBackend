using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, Result<FavoriteResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public GetFavoritesQueryHandler(UserRepository userRepository)
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
