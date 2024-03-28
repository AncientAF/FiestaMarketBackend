﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetFavoritesQuery : IRequest<Result<FavoriteResponse>>
    {
        public Guid Id { get; set; }
    }
}
