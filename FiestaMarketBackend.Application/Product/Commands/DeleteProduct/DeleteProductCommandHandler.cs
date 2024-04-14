using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Services;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, UnitResult<Error>>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IFileService _fileService;

        public DeleteProductCommandHandler(IProductsRepository productsRepository, IFileService fileService)
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
