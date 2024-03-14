using FiestaMarketBackend.Application.Commands.Product;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Handlers.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ProductsRepository _productsRepository;

        public DeleteProductCommandHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productsRepository.DeleteAsync(request.Id);

            return;
        }
    }
}
