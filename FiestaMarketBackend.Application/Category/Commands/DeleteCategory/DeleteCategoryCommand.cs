using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommand : IRequest<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
