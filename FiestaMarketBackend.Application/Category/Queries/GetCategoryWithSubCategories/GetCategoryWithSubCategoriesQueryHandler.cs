using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core.Entities;
    public class GetCategoryWithSubCategoriesQueryHandler : IRequestHandler<GetCategoryWithSubCategoriesQuery, Result<List<CategoryResponse>>>
    {
        
        private readonly CategoryRepository _categoryRepository;

        public GetCategoryWithSubCategoriesQueryHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CategoryResponse>>> Handle(GetCategoryWithSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetWithSubCategoriesAsync();
            if (result.IsFailure)
                return Result.Failure<List<CategoryResponse>>(result.Error);
            

            //TypeAdapterConfig<Category, CategoryResponse>.NewConfig().MaxDepth(5);
            return Result.Success(result.Value.Adapt<List<CategoryResponse>>());
        }
    }
}
