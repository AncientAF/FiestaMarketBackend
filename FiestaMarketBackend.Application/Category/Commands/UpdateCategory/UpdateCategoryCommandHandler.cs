using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly CategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.UpdateAsync(request.Adapt<Category>());

            return category.Adapt<CategoryResponse>();
        }
    }
}
