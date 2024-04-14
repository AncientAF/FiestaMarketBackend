namespace FiestaMarketBackend.Core
{
    public record Error
    {
        public string Code { get; }
        public string Description { get; }
        public ErrorType ErrorType { get; }
        public Dictionary<string, string>? Extensions { get; }

        public Error(ErrorType errorType, string code, string message, Dictionary<string, string> extensions)
        {
            Code = code;
            Description = message;
            ErrorType = errorType;
            Extensions = extensions;
        }

        public Error(ErrorType errorType, string code, string message)
        {
            Code = code;
            Description = message;
            ErrorType = errorType;
        }

        public static Error Failure(string code, string description) =>
            new(ErrorType.Failure, code, description);
        public static Error Validation(string code, string description, Dictionary<string, string> extensions) =>
            new(ErrorType.Validation, code, description, extensions);
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
