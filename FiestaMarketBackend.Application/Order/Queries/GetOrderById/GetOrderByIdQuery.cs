﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Order
{
    public class GetOrderByIdQuery : ICachedQuery<Result<OrderResponse, Error>>
    {
        public Guid Id { get; set; }

        public string Key => $"order-by-id{Id}";

        public TimeSpan? Expiration => default;
    }
}
