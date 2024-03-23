using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateCategoryCommand : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category? ParentCategory { get; set; }
    }
}
