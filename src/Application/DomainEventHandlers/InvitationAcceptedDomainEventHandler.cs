using System.Threading;
using System.Threading.Tasks;

using Clean.Architecture.Domain.DomainEvents;

using MediatR;

namespace Clean.Architecture.Application.DomainEventHandlers
{
    internal sealed class InvitationAcceptedDomainEventHandler : INotificationHandler<InvitationAcceptedDomainEvent>
    {
        public Task Handle(InvitationAcceptedDomainEvent notification, CancellationToken cancellationToken)
        {
            // Logic to handle post Invitation actions

            return Task.CompletedTask;
        }
    }
}
