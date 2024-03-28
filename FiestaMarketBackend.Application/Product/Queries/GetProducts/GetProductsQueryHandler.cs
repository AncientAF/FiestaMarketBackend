using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<ProductResponse>>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<List<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetAsync();

            if (result.IsFailure)
                return Result.Failure<List<ProductResponse>>(result.Error);

            return Result.Success(result.Value.Adapt<List<ProductResponse>>());
        }
    }
}
