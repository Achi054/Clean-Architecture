using System.Collections.Generic;

namespace Clean.Architecture.Concerns.Result
{
    public sealed record ValidationErrorResult : ErrorResult
    {
        public ValidationErrorResult(string message)
            : base(message)
        {
        }

        public ValidationErrorResult(string message, IReadOnlyCollection<ValidationError> errors)
            : base(message, errors) 
        {
        }
    }
}
