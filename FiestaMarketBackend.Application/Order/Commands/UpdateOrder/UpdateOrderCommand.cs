using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public OrderStatus Status { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
