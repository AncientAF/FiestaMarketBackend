using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly CategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddAsync(request.Name, request.ParentCategory);

            return;
        }
    }
}
