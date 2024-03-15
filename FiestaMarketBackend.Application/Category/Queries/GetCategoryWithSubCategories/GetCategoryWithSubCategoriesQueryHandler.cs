using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Category.Queries.GetCategoryWithSubCategories
{
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

            return result.Adapt<List<CategoryResponse>>();
        }
    }
}
