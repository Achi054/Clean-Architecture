using System;

using Clean.Architecture.Domain.Shared;

namespace Clean.Architecture.Domain.DomainEvents
{
    public sealed record InvitationAcceptedDomainEvent(Guid InvitationId, Guid GatheringId) : IDomainEvent;
}
