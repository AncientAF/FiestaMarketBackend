using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.News
{
    public class DeleteNewsCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public string[] Keys => [$"news-by-id{Id}"];
    }
}
