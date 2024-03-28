using CSharpFunctionalExtensions;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly CategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = await _categoryRepository.AddAsync(request.Name, request.ParentCategoryID);

            if (id.IsFailure)
                return Result.Failure<Guid>(id.Error);

            return Result.Success(id.Value);
        }
    }
}
