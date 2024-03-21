﻿using FiestaMarketBackend.Application.Responses;
using MediatR;

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