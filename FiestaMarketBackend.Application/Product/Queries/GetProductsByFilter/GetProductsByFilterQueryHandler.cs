using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product
{
    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, Result<List<ProductResponse>, Error>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsByFilterQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<List<ProductResponse>, Error>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByFilterAsync(request.Name, request.Category);

            if (result.IsFailure)
                return Result.Failure<List<ProductResponse>, Error>(result.Error);

            return Result.Success<List<ProductResponse>, Error>(result.Value.Adapt<List<ProductResponse>>());
        }
    }
}
