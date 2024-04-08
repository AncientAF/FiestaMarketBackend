﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse, Error>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductByIdQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<ProductResponse, Error>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<ProductResponse, Error>(result.Error);

            return Result.Success<ProductResponse, Error>(result.Value.Adapt<ProductResponse>());
        }
    }
}
