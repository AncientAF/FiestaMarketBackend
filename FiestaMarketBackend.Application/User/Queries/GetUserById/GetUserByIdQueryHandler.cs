﻿using CSharpFunctionalExtensions;
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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly UserRepository _userRepository;

        public GetUserByIdQueryHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<UserResponse>(result.Error);

            return Result.Success(result.Value.Adapt<UserResponse>());
        }
    }
}
