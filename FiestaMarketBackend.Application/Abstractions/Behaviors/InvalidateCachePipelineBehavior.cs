using FiestaMarketBackend.Application.Abstractions.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Abstractions.Behaviors
{
    public class InvalidateCachePipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IInvalidateCacheCommand
    {
        private readonly ICacheService _cacheService;

        public InvalidateCachePipelineBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            foreach (var key in request.Keys)
                _cacheService.DeleteAsync(key, cancellationToken);

            return next();
        }
    }
}
