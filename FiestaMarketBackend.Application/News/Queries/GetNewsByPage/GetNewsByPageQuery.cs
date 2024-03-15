using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Queries.GetNewsByPage
{
    public class GetNewsByPageQuery : IRequest<List<NewsResponse>>
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
