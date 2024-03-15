using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Products.Queries.GetProductsByFilter
{
    internal class GetProductsByPageQuery : IRequest<List<ProductResponse>>
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
