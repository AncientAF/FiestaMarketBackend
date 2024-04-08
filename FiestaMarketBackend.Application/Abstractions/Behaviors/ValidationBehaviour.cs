using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace FiestaMarketBackend.Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandBase
        where TResponse : IResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(validator => validator.Validate(context))
                .Where(validationResult => !validationResult.IsValid)
                .Distinct()
                .SelectMany(validationResult => validationResult.Errors)
                .ToDictionary(e => e.PropertyName, e => e.ErrorMessage);

            if (errors.Any())
                return CreateValidationResult<TResponse>(errors);

            var result = await next();

            return result;
        }

        private TResult CreateValidationResult<TResult>(Dictionary<string, string> errors)
        {
            var errMsg = Error.Validation("ValidationError", "A validation error has occurred", errors);

            using (LogContext.PushProperty("Error", errMsg, true))
            {
                _logger.LogError("Completed request {RequestName} with errors", typeof(TRequest).Name);
            }

            if (typeof(TResult) == typeof(UnitResult))
            {
                return (TResult)(Object)UnitResult.Failure(errMsg);
            }

            var type = typeof(Result);

            var methodInfo = type.GetMethods().Where(m => m.Name == "Failure").Last();

            var genericType = typeof(TResponse).GenericTypeArguments[0];

            var genMethod = methodInfo.MakeGenericMethod(genericType, typeof(Error));

            var result = genMethod.Invoke(null, new object?[] { errMsg });

            return (TResult)result!;
        }
    }
}
