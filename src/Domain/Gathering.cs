using System;
using System.Collections.Generic;

using Clean.Architecture.Domain.Shared;

namespace Clean.Architecture.Domain
{
    internal sealed class Gathering : Entity
    {
        private readonly List<Invitation> _invitations = new();
        private readonly List<Attendee> _attendees = new();

        private Gathering(
            Guid id,
            Member creator,
            GatheringType type,
            DateTime scheduledAtUtc,
            string name,
            string? location)
            : base(id)
        {
            Creator = creator;
            Type = type;
            ScheduledAtUtc = scheduledAtUtc;
            Name = name;
            Location = location;
        }

        public enum GatheringType
        {
            WithFixedNumberOfAttendees,
            WithExpirationForInvitation,
        }

        public Member Creator { get; private set; }

        public GatheringType Type { get; private set; }

        public string Name { get; private set; }

        public DateTime ScheduledAtUtc { get; private set; }

        public string? Location { get; private set; }

        public int? MaximumNumberOfAttendees { get; private set; }

        public DateTime? InvitationExpireUtc { get; private set; }

        public int NumberOfAttendees { get; private set; }

        public IReadOnlyCollection<Attendee> Attendees => _attendees;

        public IReadOnlyCollection<Invitation> Invitations => _invitations;

        public static Gathering Create(
            Guid id,
            Member creator,
            GatheringType type,
            DateTime scheduledAtUtc,
            string name,
            string? location,
            int maximumNumberOfAttendees,
            int invitationValidBeforeInHours)
        {
            Gathering gathering = new(id, creator, type, scheduledAtUtc, name, location);

            switch (gathering.Type)
            {
                case GatheringType.WithFixedNumberOfAttendees:
                    gathering.MaximumNumberOfAttendees = maximumNumberOfAttendees;
                    break;
                case GatheringType.WithExpirationForInvitation:
                    gathering.InvitationExpireUtc = gathering.ScheduledAtUtc.AddHours(-invitationValidBeforeInHours);
                    break;
                default:
                    throw new InvalidCastException(nameof(GatheringType));
            }

            return gathering;
        }

        internal Invitation SendInvitation(Member member)
        {
            if (Creator.Id == member.Id)
            {
                throw new Exception("Can't send invitation to the gathering creator.");
            }

            if (ScheduledAtUtc < DateTime.UtcNow)
            {
                throw new Exception("Can't send invitation to the gathering in the past.");
            }

            Invitation invitation = new(Guid.NewGuid(), member, this);

            _invitations.Add(invitation);

            return invitation;
        }

        internal Attendee? AcceptInvitation(Invitation invitation)
        {
            var expired = (Type == GatheringType.WithFixedNumberOfAttendees && NumberOfAttendees == MaximumNumberOfAttendees)
                       || (Type == GatheringType.WithExpirationForInvitation && InvitationExpireUtc < DateTime.UtcNow);

            if (expired)
            {
                invitation.Expire();
                return null;
            }

            var attendee = invitation.Accept();

            _attendees.Add(attendee);
            NumberOfAttendees++;

            return attendee;
        }
    }
}
