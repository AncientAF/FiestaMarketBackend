using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : ICommand<Result<NewsResponse, Error>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? DescriptionMarkDown { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}
