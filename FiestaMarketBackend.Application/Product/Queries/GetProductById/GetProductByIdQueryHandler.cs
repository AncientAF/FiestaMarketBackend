using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse, Error>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductByIdQueryHandler(IProductsRepository productsRepository)
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
