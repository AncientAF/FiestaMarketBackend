using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<CategoryResponse, Error>>
    {
        private readonly CategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryResponse, Error>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.UpdateAsync(request.Adapt<Category>());

            if (category.IsFailure)
                return Result.Failure<CategoryResponse, Error>(category.Error);

            return Result.Success<CategoryResponse, Error>(category.Adapt<CategoryResponse>());
        }
    }
}
