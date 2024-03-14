using FiestaMarketBackend.Application.Commands.Product;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Handlers.Product
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
