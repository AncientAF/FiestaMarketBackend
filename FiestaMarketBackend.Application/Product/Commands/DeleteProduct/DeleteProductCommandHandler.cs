using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Services;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, UnitResult<Error>>
    {
        private readonly ProductsRepository _productsRepository;
        private readonly FileService _fileService;

        public DeleteProductCommandHandler(ProductsRepository productsRepository, FileService fileService)
        {
            _productsRepository = productsRepository;
            _fileService = fileService;
        }

        public async Task<UnitResult<Error>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var imagesResult = await _productsRepository.GetImagesAsync(request.Id);

            if (imagesResult.IsFailure)
                return UnitResult.Failure(imagesResult.Error);

            var repoResult = await _productsRepository.DeleteAsync(request.Id);

            if (repoResult.IsFailure)
                return UnitResult.Failure(repoResult.Error);

            var fileResult = _fileService.DeleteImages(imagesResult.Value);

            if (fileResult.IsFailure)
                return UnitResult.Failure(fileResult.Error);

            return UnitResult.Success<Error>();
        }
    }
}
