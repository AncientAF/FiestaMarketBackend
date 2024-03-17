using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Products.Queries
{
    using FiestaMarketBackend.Core.Entities;
    public class GetProductsByFilterQuery : IRequest<List<ProductResponse>>
    {
        public string name;
        public Category Category;

        public GetProductsByFilterQuery(string name, Category category)
        {
            this.name = name;
            Category = category;
        }
    }
}
