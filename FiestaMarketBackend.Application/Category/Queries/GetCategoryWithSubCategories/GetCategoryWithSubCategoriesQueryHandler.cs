using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using FiestaMarketBackend.Core.Entities;
    public class GetCategoryWithSubCategoriesQueryHandler : IRequestHandler<GetCategoryWithSubCategoriesQuery, List<CategoryResponse>>
    {
        
        private readonly CategoryRepository _categoryRepository;

        public GetCategoryWithSubCategoriesQueryHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> Handle(GetCategoryWithSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetWithSubCategoriesAsync();

            //TypeAdapterConfig<Category, CategoryResponse>.NewConfig().MaxDepth(5);
            return result.Adapt<List<CategoryResponse>>();
        }
    }
}
