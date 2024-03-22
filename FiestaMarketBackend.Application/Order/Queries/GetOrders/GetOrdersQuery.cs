using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderResponse>>
    {

    }
}
