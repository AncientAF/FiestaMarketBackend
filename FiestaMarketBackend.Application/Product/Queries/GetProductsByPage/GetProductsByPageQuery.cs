using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsByPageQuery : IRequest<Result<List<ProductResponse>>>
    {
        public GetProductsByPageQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
