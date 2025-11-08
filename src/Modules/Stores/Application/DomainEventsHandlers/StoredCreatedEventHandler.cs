using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Stores.Domain.DomainEvents;

namespace Hababk.Modules.Stores.Application.DomainEventsHandlers;

public class StoredCreatedEventHandler :IDomainEventHandler<StoreCreatedEvent>
{
    public Task Handle(StoreCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("dsfdsfsd");
        return Task.CompletedTask;
    }
}