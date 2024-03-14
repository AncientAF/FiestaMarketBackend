using FiestaMarketBackend.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Commands.Product
{
    public class UpdateProductCommand : IRequest
    {
        public UpdateProductCommand(string name, string fullName, Category category, decimal price, int minQuantity, bool relevant, bool recommended, List<Image> images, ProductDescription description)
        {
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

        public string Name { get; set; }
        public string FullName { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public bool Relevant { get; set; }
        public bool Recommended { get; set; }
        public List<Image> Images { get; set; }
        public ProductDescription Description { get; set; }
    }
}
