using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using FluentValidation;
using MediatR;

namespace FiestaMarketBackend.Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandBase
        where TResponse : IResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(validator => validator.Validate(context))
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .ToDictionary(e => e.PropertyName, e => e.ErrorMessage);

            if (errors.Any())
            {
                return CreateValidationResult<TResponse>(errors);
            }

            var result = await next();

            return result;
        }

        private static TResult CreateValidationResult<TResult>(Dictionary<string, string> errors)
        {
            if (typeof(TResult) == typeof(UnitResult))
                return (TResult)(Object)UnitResult.Failure(Error.Validation("ValidationError", "A validation error has occurred", errors));

            var type = typeof(Result);

            var methodInfo = type.GetMethods().Where(m => m.Name == "Failure").Last();

            var genericType = typeof(TResponse).GenericTypeArguments[0];

            var genMethod = methodInfo.MakeGenericMethod(genericType, typeof(Error));

            var result = genMethod.Invoke(null, new object?[] { Error.Validation("ValidationError", "A validation error has occurred", errors) });

            return (TResult)result!;
        }
    }
}
