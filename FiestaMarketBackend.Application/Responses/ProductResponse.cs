namespace FiestaMarketBackend.Application.Responses
{
    using FiestaMarketBackend.Core.Entities;
    public class ProductResponse
    {

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public bool Relevant { get; set; }
        public bool Recommended { get; set; }
        public List<Image> Images { get; set; }
        public ProductDescription Description { get; set; }
        public ProductResponse(System.Guid id, string name, string fullName, Category category, decimal price, int minQuantity, bool relevant, bool recommended, List<Image> images, ProductDescription description)
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
