namespace FiestaMarketBackend.Application.Product
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Caching;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateProductCommand : IInvalidateCacheCommand<Result<ProductResponse, Error>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public Category? Category { get; set; }
        public decimal? Price { get; set; }
        public int? MinQuantity { get; set; }
        public bool? Relevant { get; set; }
        public bool? Recommended { get; set; }
        public ProductDescription? Description { get; set; }

        public string[] Keys => [$"product-by-id{Id}"];
    }
}
