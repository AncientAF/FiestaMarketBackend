using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ProductsRepository _productsRepository;

        public UpdateProductCommandHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productsRepository.AddAsync(request.Adapt<Product>());

            return;
        }
    }
}
