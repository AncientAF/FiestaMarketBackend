using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
