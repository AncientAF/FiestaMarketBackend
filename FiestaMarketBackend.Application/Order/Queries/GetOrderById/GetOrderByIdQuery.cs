﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Queries
{
    public class GetOrderByIdQuery : ICommand<Result<OrderResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
