﻿using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateProductCommand : ICommand<Result<ProductResponse, Error>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public Category? Category { get; set; }
        public decimal? Price { get; set; }
        public int? MinQuantity { get; set; }
        public bool? Relevant { get; set; }
        public bool? Recommended { get; set; }
        public List<Image>? Images { get; set; }
        public ProductDescription? Description { get; set; }
    }
}
