using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductsByFilterQuery : IRequest<List<ProductResponse>>
    {
        public GetProductsByFilterQuery(string? name, Guid? category)
        {
            Name = name;
            Category = category;
        }
        public string? Name { get; set; }
        public Guid? Category { get; set; }

    }
}
