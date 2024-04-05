using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    internal class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, Result<List<ProductResponse>, Error>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsByPageQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<List<ProductResponse>, Error>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            if (result.IsFailure)
                return Result.Failure<List<ProductResponse>, Error>(result.Error);

            return Result.Success<List<ProductResponse>, Error>(result.Value.Adapt<List<ProductResponse>>());
        }
    }
}
