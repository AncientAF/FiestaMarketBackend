using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductByIdQuery : ICommand<Result<ProductResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
