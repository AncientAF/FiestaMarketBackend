using MediatR;

namespace FiestaMarketBackend.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
