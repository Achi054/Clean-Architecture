namespace Clean.Architecture.Concerns.Result
{
    public sealed record ValidationError : Error
    {
        public ValidationError(string propertyName, string details)
            : base(null, details)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { get; set; }
    }
}
