using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetCartQuery : IRequest<Result<CartResponse>>
    {
        public Guid Id { get; set; }
    }
}
