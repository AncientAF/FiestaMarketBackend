using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Queries
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
