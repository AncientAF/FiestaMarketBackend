using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ProductsRepository _productsRepository;
        private readonly FileService _fileService;

        public DeleteProductCommandHandler(ProductsRepository productsRepository, FileService fileService)
        {
            _productsRepository = productsRepository;
            _fileService = fileService;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var images = await _productsRepository.GetImages(request.Id);
            await _productsRepository.DeleteAsync(request.Id);
            _fileService.DeleteImages(images);

            return;
        }
    }
}
