using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid, Error>>
    {
        private readonly ProductsRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly FileService _fileService;

        public CreateProductCommandHandler(ProductsRepository productRepository, CategoryRepository categoryRepository, FileService fileService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Result<Guid, Error>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = request.Adapt<Product>();

            if (request.Images != null)
            {
                var resultTemp = await _fileService.AddImages(request.Images);

                if (resultTemp.IsFailure)
                    return Result.Failure<Guid, Error>(resultTemp.Error);

                productToAdd.Images = resultTemp.Value;
            }

            if (request.CategoryId != null)
            {
                var resultTemp = await _categoryRepository.GetByIdAsync(request.CategoryId);

                if (resultTemp.IsFailure)
                    return Result.Failure<Guid, Error>(resultTemp.Error);

                productToAdd.Category = resultTemp.Value;
            }

            var result = await _productRepository.AddAsync(productToAdd);

            if (result.IsFailure)
                return Result.Failure<Guid, Error>(result.Error);

            return Result.Success<Guid, Error>(result.Value);
        }
    }
}
