using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace FiestaMarketBackend.API.Extensions
{
    public static class ErrorExtensions
    {

        public static IResult ToProblemDetails<T>(this Result<T,Error> result)
        {
            return Results.Problem(
                statusCode: GetStatusCode(result.Error.ErrorType),
                title: GetTitle(result.Error.ErrorType),
                type: GetType(result.Error.ErrorType),
                detail: result.Error.Description);
                //extensions: new Dictionary<string, Object?>
                //{
                //    { "errors", new [] {result.Error} }
                //});
        }

        public static IResult ToProblemDetails(this UnitResult<Error> result)
        {
            return Results.Problem(
                statusCode: GetStatusCode(result.Error.ErrorType),
                title: GetTitle(result.Error.ErrorType),
                type: GetType(result.Error.ErrorType),
                detail: result.Error.Description);
            //extensions: new Dictionary<string, Object?>
            //{
            //    { "errors", new [] {result.Error} }
            //});
        }

        private static int GetStatusCode(ErrorType errorType) =>
                errorType switch
                {
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError,
                };

        private static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                _ => "Server error",
            };

        private static string GetType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            };
    }
}
