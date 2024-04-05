using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : IRequest<Result<NewsResponse, Error>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
