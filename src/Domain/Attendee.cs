using System;

namespace Clean.Architecture.Domain
{
    internal sealed class Attendee
    {
        public Attendee(Invitation invitation)
        {
            GatheringId = invitation.GatheringId;
            MemberId = invitation.MemberId;
            CreatedOnUtc = DateTime.UtcNow;
        }

        public Guid GatheringId { get; private set; }

        public Guid MemberId { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }
    }
}
