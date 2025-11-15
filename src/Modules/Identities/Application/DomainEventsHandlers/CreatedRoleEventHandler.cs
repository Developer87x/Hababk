using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Domain.DomainEvents;

namespace Hababk.Modules.Identities.Application.DomainEventsHandlers;

public class CreatedRoleEventHandler : IDomainEventHandler<CreatedRoleDomainEvent>
{
    public Task Handle(CreatedRoleDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}