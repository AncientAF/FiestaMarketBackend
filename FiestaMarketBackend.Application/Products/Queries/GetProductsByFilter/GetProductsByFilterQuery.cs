using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Products.Queries.GetProductsByFilter
{
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
