namespace Clean.Architecture.Concerns.Result
{
    public abstract record Result
    {
        public bool Success { get; protected set; }

        public bool Failure => !Success;
    }
}
