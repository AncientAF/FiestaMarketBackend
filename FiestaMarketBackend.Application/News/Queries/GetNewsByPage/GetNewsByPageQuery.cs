using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByPageQuery : ICachedQuery<Result<List<NewsResponse>, Error>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public string Key => $"news-by-page-{PageIndex}-{PageSize}";

        public TimeSpan? Expiration => default;
    }
}
