using System;

using Clean.Architecture.Domain.Shared;

namespace Clean.Architecture.Domain
{
    internal sealed class Invitation : Entity
    {
        internal Invitation(
           Guid id,
           Member member,
           Gathering gathering)
        {
            Id = id;
            MemberId = member.Id;
            GatheringId = gathering.Id;
            Status = InvitationStatus.Pending;
            CreatedOnUtc = DateTime.UtcNow;
        }

        public enum InvitationStatus
        {
            Pending,
            Expired,
            Accepted,
        }

        public Guid GatheringId { get; private set; }

        public Guid MemberId { get; private set; }

        public InvitationStatus Status { get; private set; }

        public void Expire()
        {
            Status = InvitationStatus.Expired;
            ModifiedOnUtc = DateTime.UtcNow;
        }

        public Attendee Accept()
        {
            Status = InvitationStatus.Accepted;
            ModifiedOnUtc = DateTime.UtcNow;

            return new Attendee(this);
        }
    }
}
