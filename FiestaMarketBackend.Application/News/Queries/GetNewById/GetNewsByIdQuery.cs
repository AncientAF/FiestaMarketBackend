using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByIdQuery : ICachedQuery<Result<NewsResponse, Error>>
    {
        public Guid Id { get; set; }

        public string Key => $"news-by-id{Id}";

        public TimeSpan? Expiration => default;
    }
}
