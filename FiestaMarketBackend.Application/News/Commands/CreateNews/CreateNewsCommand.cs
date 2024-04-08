using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : ICommand<Result<Guid, Error>>
    {
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string DescriptionMarkDown { get; set; }
    }
}
