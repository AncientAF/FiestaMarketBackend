using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
