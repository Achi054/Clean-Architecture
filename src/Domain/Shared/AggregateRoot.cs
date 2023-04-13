using System;
using System.Collections.Generic;
using System.Linq;

namespace Clean.Architecture.Domain.Shared
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _events = new();

        public AggregateRoot(Guid id)
            : base(id)
        {
        }

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _events.ToList();

        public void ClearDomainEvents() => _events.Clear();
    }
}
