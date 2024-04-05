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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserResponse>, Error>>
    {
        private readonly UserRepository _userRepository;

        public GetAllUsersQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserResponse>, Error>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAsync();

            if (result.IsFailure)
                return Result.Failure<List<UserResponse>, Error>(result.Error);

            return Result.Success<List<UserResponse>, Error>(result.Value.Adapt<List<UserResponse>>());
        }
    }
}
