using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product
{
    public class GetProductsByPageQuery : IQuery<Result<List<ProductResponse>, Error>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
