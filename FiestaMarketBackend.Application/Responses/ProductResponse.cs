using FiestaMarketBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Responses
{
    public class ProductResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public bool Relevant { get; set; }
        public bool Recommended { get; set; }
        public List<Image> Images { get; set; }
        public ProductDescription Description { get; set; }
        public ProductResponse(Guid id, string name, string fullName, Category category, decimal price, int minQuantity, bool relevant, bool recommended, List<Image> images, ProductDescription description)
        {
            Id = id;
            Name = name;
            FullName = fullName;
            Category = category;
            Price = price;
            MinQuantity = minQuantity;
            Relevant = relevant;
            Recommended = recommended;
            Images = images;
            Description = description;
        }
    }
}
