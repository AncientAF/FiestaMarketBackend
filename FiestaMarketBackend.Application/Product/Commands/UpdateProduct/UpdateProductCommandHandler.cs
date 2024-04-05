using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse, Error>>
    {
        private readonly ProductsRepository _productsRepository;

        public UpdateProductCommandHandler(ProductsRepository productsRepository)
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
