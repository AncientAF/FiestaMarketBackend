using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid, Error>>
    {
        private readonly CategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(CategoryRepository categoryRepository)
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
