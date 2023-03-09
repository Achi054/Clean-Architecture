using System;

using Clean.Architecture.Domain.Shared;

namespace Clean.Architecture.Domain
{
    internal sealed class Member : Entity
    {
        public Member(
            Guid id,
            string firstName,
            string lastName,
            string email)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }
    }
}
