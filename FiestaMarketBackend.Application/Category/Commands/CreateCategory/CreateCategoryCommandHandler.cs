using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly CategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = await _categoryRepository.AddAsync(request.Name, request.ParentCategoryID);

            return id;
        }
    }
}
