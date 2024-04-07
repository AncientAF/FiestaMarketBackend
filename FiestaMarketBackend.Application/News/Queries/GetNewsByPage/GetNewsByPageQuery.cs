﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByPageQuery : ICommand<Result<List<NewsResponse>, Error>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
