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
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Result<CartResponse>>
    {
        private readonly UserRepository _userRepository;

        public GetCartQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetCartAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<CartResponse>(result.Error);

            return Result.Success(result.Value.Adapt<CartResponse>());
        }
    }
}
