using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
