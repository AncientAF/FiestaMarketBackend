using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
