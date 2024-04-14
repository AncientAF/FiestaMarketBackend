using CSharpFunctionalExtensions;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Product
{
    using FiestaMarketBackend.Application.Abstractions.Services;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid, Error>>
    {
        private readonly IProductsRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductsRepository productRepository, ICategoryRepository categoryRepository, IFileService fileService)
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
