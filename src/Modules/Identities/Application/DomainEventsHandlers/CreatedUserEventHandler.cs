using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Domain.DomainEvents;

namespace Hababk.Modules.Identities.Application.DomainEventsHandlers;

public class CreatedUserEventHandler : IDomainEventHandler<CreatedUserDomainEvent>
{
    public Task Handle(CreatedUserDomainEvent notification, CancellationToken cancellationToken)
    {
       return Task.CompletedTask;
    }
}