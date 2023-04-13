using System;

using Clean.Architecture.Domain.Shared;
using Clean.Architecture.Domain.ValueObjects;

namespace Clean.Architecture.Domain
{
    internal sealed class Member : Entity
    {
        public Member(
            Guid id,
            FirstName firstName,
            LastName lastName,
            Email email)  
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; } 
    }
}
