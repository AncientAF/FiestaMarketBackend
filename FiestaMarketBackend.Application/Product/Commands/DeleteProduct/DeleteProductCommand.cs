using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommand : ICommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
    }
}
