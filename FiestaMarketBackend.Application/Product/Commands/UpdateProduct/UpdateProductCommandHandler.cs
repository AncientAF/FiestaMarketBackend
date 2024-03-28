using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResponse>>
    {
        private readonly ProductsRepository _productsRepository;

        public UpdateProductCommandHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Result<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.UpdateAsync(request.Adapt<Product>());

            if (result.IsFailure)
                return Result.Failure<ProductResponse>(result.Error);

            return Result.Success(result.Value.Adapt<ProductResponse>());
        }
    }
}
