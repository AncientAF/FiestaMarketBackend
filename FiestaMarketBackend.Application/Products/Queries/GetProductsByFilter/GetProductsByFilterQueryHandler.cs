using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, List<ProductResponse>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsByFilterQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByFilterAsync(request.name, request.Category);

            return result.Adapt<List<ProductResponse>>();
        }
    }
}
