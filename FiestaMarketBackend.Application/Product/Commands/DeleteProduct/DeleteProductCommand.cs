using MediatR;

namespace FiestaMarketBackend.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
