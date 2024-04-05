﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetCartQuery : IRequest<Result<CartResponse, Error>>
    {
        public Guid Id { get; set; }
    }
}
