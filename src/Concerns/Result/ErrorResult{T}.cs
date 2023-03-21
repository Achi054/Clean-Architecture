using System;
using System.Collections.Generic;

namespace Clean.Architecture.Concerns.Result
{
    public sealed record ErrorResult<T> : Result<T>, IErrorResult
    {
        public ErrorResult(string message)
            : this(message, Array.Empty<Error>())
        {
        }

        public ErrorResult(string message, IReadOnlyCollection<Error> errors)
            : base(default(T))
        {
            this.Message = message ?? string.Empty;
            this.Success = false;
            this.Errors = errors ?? Array.Empty<Error>();
        }

        public string Message { get; }

        public IReadOnlyCollection<Error> Errors { get; }
    }
}
