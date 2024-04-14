using FiestaMarketBackend.Application.Responses;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse, Error>>
    {
        private readonly IProductsRepository _productsRepository;

        public UpdateProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<ProductResponse, Error>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.UpdateAsync(request.Adapt<Product>());

            if (result.IsFailure)
                return Result.Failure<ProductResponse, Error>(result.Error);

            return Result.Success<ProductResponse, Error>(result.Value.Adapt<ProductResponse>());
        }
    }
}
