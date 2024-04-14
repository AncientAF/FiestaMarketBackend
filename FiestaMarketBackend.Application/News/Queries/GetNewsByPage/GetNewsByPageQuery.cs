using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News
{
    public class GetNewsByPageQuery : IQuery<Result<List<NewsResponse>, Error>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
