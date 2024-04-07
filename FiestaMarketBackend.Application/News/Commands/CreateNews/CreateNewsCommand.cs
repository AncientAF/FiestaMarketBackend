using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : ICommand<Result<Guid, Error>>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
    }
}
