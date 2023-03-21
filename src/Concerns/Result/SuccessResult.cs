namespace Clean.Architecture.Concerns.Result
{
    public sealed record SuccessResult : Result
    {
        public SuccessResult() => Success = true;
    }
}
