using FiestaMarketBackend.Application.Responses;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Repositories;

    public class GetCategoryWithSubCategoriesQueryHandler : IRequestHandler<GetCategoryWithSubCategoriesQuery, Result<List<CategoryResponse>, Error>>
    {

        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryWithSubCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CategoryResponse>, Error>> Handle(GetCategoryWithSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetWithSubCategoriesAsync();
            if (result.IsFailure)
                return Result.Failure<List<CategoryResponse>, Error>(result.Error);


            //TypeAdapterConfig<Category, CategoryResponse>.NewConfig().MaxDepth(5);
            return Result.Success<List<CategoryResponse>, Error>(result.Value.Adapt<List<CategoryResponse>>());
        }
    }
}
