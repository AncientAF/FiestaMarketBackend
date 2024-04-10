using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>;
}
