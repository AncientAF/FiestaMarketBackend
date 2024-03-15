using FiestaMarketBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Responses
{
    using FiestaMarketBackend.Core.Entities;

    public class CategoryResponse
    {

        public CategoryResponse(Guid id, string name, List<Product> products, Category parentCategory, List<Category> subCategories)
        {
            Id = id;
            Name = name;
            Products = products;
            ParentCategory = parentCategory;
            SubCategories = subCategories;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
