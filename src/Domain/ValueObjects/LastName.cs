using System;

namespace Clean.Architecture.Domain.ValueObjects
{
    internal sealed record LastName
    {
        private LastName() { }

        public string Value { get; private set; } = default!;

        public LastName Create(string value) 
        {
            if (value.Length <= 3)
            {
                throw new ArgumentException($"{nameof(value)} cannot be less than 3 characters.");
            }

            this.Value = value;

            return this;
        }
    }
}
