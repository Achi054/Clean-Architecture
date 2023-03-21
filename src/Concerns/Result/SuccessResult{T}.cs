namespace Clean.Architecture.Concerns.Result
{
    public sealed record SuccessResult<T> : Result<T>
    {
        public SuccessResult(T data)
            : base(data)
            => Success = true;
    }
}
