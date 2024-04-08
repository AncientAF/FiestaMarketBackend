using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByIdQuery : ICommand<Result<NewsResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
