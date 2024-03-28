using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    internal class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, Result<List<ProductResponse>>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsByPageQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<List<ProductResponse>>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            if (result.IsFailure)
                return Result.Failure<List<ProductResponse>>(result.Error);

            return Result.Success(result.Value.Adapt<List<ProductResponse>>());
        }
    }
}
