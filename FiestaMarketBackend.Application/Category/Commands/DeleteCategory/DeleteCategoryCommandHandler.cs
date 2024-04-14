using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, UnitResult<Error>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteAsync(request.Id);

            if (result.IsFailure)
                return UnitResult.Failure<Error>(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}
