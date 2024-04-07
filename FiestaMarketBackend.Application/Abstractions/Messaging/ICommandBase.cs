using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest, ICommandBase
    {
    }

    public interface ICommand<TResponse> : IRequest<TResponse>, ICommandBase
    {
    }

    public interface ICommandBase 
    {
    }
}
