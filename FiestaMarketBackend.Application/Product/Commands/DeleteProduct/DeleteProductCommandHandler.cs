using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly ProductsRepository _productsRepository;
        private readonly FileService _fileService;

        public DeleteProductCommandHandler(ProductsRepository productsRepository, FileService fileService)
        {
            _productsRepository = productsRepository;
            _fileService = fileService;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var imagesResult = await _productsRepository.GetImagesAsync(request.Id);

            if (imagesResult.IsFailure)
                return Result.Failure(imagesResult.Error);

            var repoResult = await _productsRepository.DeleteAsync(request.Id);

            if (repoResult.IsFailure) 
                return Result.Failure(repoResult.Error);

            var fileResult = _fileService.DeleteImages(imagesResult.Value);

            if (fileResult.IsFailure)
                return Result.Failure(fileResult.Error);

            return Result.Success();
        }
    }
}
