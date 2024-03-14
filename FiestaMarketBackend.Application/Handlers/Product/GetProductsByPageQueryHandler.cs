using FiestaMarketBackend.Application.Queries;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Handlers
{
    internal class GetProductsByPageQueryHandler : IRequestHandler<GetProductsByPageQuery, List<ProductResponse>>
    {
        private readonly ProductsRepository _productsRepository;

        public GetProductsByPageQueryHandler(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _productsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            return request.Adapt<List<ProductResponse>>();
        }
    }
}
