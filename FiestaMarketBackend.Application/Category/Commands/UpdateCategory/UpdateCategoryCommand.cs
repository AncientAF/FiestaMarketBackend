using MediatR;

namespace FiestaMarketBackend.Application.Category.Commands.UpdateCategory
{
    using FiestaMarketBackend.Core.Entities;
    public class UpdateCategoryCommand : IRequest
    {
        public UpdateCategoryCommand(Guid id, string name, Category parentCategory)
        {
            Id = id;
            Name = name;
            ParentCategory = parentCategory;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
    }
}
