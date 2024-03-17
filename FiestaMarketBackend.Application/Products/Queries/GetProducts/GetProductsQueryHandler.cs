using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetAsync();

            return result.Adapt<List<ProductResponse>>();
        }
    }
}
