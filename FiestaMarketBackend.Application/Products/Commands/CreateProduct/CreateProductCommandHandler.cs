using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
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

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = request.Adapt<Product>();

            if(request.Images != null)
                productToAdd.Images = await _fileService.AddImages(request.Images);

            if (request.CategoryId != null)
                productToAdd.Category = await _categoryRepository.GetByIdAsync(request.CategoryId);
             
            await _productRepository.AddAsync(productToAdd);

            return;
        }
    }
}
