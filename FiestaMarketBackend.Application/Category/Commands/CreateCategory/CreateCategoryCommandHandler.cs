using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid, Error>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid, Error>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = await _categoryRepository.AddAsync(request.Name, request.ParentCategoryID);

            if (id.IsFailure)
                return Result.Failure<Guid, Error>(id.Error);

            return Result.Success<Guid, Error>(id.Value);
        }
    }
}
