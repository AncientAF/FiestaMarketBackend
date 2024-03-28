using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByPageQuery : IRequest<Result<List<NewsResponse>>>
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
