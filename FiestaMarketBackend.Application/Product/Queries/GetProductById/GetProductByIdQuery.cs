using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Product.Queries
{
    public class GetProductByIdQuery : ICommand<Result<ProductResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
