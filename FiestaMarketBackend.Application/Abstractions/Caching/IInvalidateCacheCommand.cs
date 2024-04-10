using FiestaMarketBackend.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Abstractions.Caching
{
    public interface IInvalidateCacheCommand
    {
        string[] Keys { get;}
    }

    public interface IInvalidateCacheCommand<TResponse> : ICommand<TResponse>, IInvalidateCacheCommand;
}
