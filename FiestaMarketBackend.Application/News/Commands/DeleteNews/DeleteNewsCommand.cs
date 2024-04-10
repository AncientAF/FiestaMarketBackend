using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"news-by-id{Id}"];
    }
}
