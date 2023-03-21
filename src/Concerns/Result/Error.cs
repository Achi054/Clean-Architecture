namespace Clean.Architecture.Concerns.Result
{
    public record Error
    {
        public Error(string details)
            : this(null, details)
        {
        }

        public Error(string? code, string details)
        {
            this.Code = code;
            this.Details = details;
        }

        public string? Code { get; }

        public string Details { get; }
    }
}
