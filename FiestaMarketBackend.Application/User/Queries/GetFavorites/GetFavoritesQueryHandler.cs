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
    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, FavoriteResponse>
    {
        private readonly UserRepository _userRepository;

        public GetFavoritesQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<FavoriteResponse> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetFavoriteAsync(request.Id);

            return result.Adapt<FavoriteResponse>();
        }
    }
}
