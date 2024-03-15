using MediatR;

namespace FiestaMarketBackend.Application.Category.Commands.AddCategory
{
    using FiestaMarketBackend.Core.Entities;
    public class AddCategoryCommand : IRequest
    {
        public AddCategoryCommand(string name, Category parentCategory)
        {
            Name = name;
            ParentCategory = parentCategory;
        }

        public string Name { get; set; }
        public Category ParentCategory { get; set; }
    }
}
