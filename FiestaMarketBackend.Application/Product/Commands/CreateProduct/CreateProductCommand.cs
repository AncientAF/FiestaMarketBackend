using Microsoft.AspNetCore.Http;

namespace FiestaMarketBackend.Application.Product
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;

    public class CreateProductCommand : ICommand<Result<Guid, Error>>
    {

        public required string Name { get; set; }
        public required string FullName { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal Price { get; set; }
        public int MinQuantity { get; set; }
        public bool Relevant { get; set; }
        public bool Recommended { get; set; }
        public ProductDescription? Description { get; set; }
        public List<IFormFile>? Images { get; set; }

    }
}
