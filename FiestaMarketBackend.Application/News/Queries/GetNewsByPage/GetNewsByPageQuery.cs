using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByPageQuery : IRequest<Result<List<NewsResponse>, Error>>
    {
        public GetNewsByPageQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
