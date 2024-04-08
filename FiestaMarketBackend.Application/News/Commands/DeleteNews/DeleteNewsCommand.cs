using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
