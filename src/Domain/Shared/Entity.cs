using System;

namespace Clean.Architecture.Domain.Shared
{
    internal abstract class Entity : IEquatable<Entity>
    {
        public Entity(Guid id)
            => (Id, CreatedOnUtc) = (id, DateTime.UtcNow);

        public Guid Id { get; private init; }

        public DateTime CreatedOnUtc { get; private init; }

        public DateTime? ModifiedOnUtc { get; internal set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public override int GetHashCode()
            => Id.GetHashCode() * 41;

        public static bool operator ==(Entity? left, Entity? right)
        {
            return left is not null && right is not null && left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}
