﻿using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductResponse>>
    {
    }
}