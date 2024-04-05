using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByIdQuery : IRequest<Result<NewsResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
