using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Core
{
    public record Error
    {
        public string Code { get; }
        public string Description { get; }
        public ErrorType ErrorType { get; }

        public Error(ErrorType errorType, string code, string message)
        {
            Code = code;
            Description = message;
            ErrorType = errorType;
        }

        public static Error Failure(string code, string description) =>
            new(ErrorType.Failure, code, description);
        public static Error Validation(string code, string description) =>
            new(ErrorType.Validation, code, description);
        public static Error NotFound(string code, string description) =>
            new(ErrorType.NotFound, code, description);
        public static Error Conflict(string code, string description) =>
            new(ErrorType.Conflict, code, description);

    }

    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound = 2,
        Conflict = 3,
    }

}
