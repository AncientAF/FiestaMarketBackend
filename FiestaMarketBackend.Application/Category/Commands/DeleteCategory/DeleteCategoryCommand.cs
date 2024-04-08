using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
