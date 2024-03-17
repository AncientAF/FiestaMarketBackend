using MediatR;

namespace FiestaMarketBackend.Application.Products.Commands
{
    using FiestaMarketBackend.Core.Entities;
    public class CreateProductCommand : IRequest
    {

        public string Name { get; set; }
        public string FullName { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public bool Relevant { get; set; }
        public bool Recommended { get; set; }
        public List<Image>? Images { get; set; }
        public ProductDescription? Description { get; set; }

    }
}
