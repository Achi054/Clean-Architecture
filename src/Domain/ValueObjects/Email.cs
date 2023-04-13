using System;
using System.Text.RegularExpressions;

namespace Clean.Architecture.Domain.ValueObjects
{
    internal sealed record Email
    {
        private const string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        private Email() { }

        public string Value { get; private set; } = default!;

        public Email Create(string value) 
        {
            if (!Regex.IsMatch(value, emailRegex, RegexOptions.IgnoreCase))
            {
                throw new ArgumentException($"{nameof(value)} is not a valid Email.");
            }

            this.Value = value;

            return this;
        }
    }
}
