using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace FiestaMarketBackend.Application.Abstractions.Behaviors
{
    public sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IUnitResult<object>
    {

        private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Processing request {RequestName}", requestName);

            var result = await next();

            if (result.IsSuccess)
            {
                _logger.LogInformation("Completed request {RequestName}", requestName);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    _logger.LogError("Completed request {RequestName} with errors", requestName);
                }
            }

            return result;
        }
    }
}
