using System;

namespace Clean.Architecture.Domain.Shared
{
    internal abstract class Entity
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();

        public DateTime CreatedOnUtc { get; internal set; } = DateTime.UtcNow;

        public DateTime? ModifiedOnUtc { get; internal set; }
    }
}
