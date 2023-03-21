using System.Collections.Generic;

namespace Clean.Architecture.Concerns.Result
{
    internal interface IErrorResult
    {
        string Message { get; }

        IReadOnlyCollection<Error> Errors { get; }
    }
}
