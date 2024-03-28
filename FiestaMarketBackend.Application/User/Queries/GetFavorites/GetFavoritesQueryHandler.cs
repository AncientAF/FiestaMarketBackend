using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
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
    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, Result<FavoriteResponse>>
    {
        private readonly UserRepository _userRepository;

        public GetFavoritesQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<FavoriteResponse>> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetFavoriteAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<FavoriteResponse>(result.Error);

            return Result.Success(result.Value.Adapt<FavoriteResponse>());
        }
    }
}
