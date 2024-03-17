using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Queries
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
