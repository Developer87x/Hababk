using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;

namespace Hababk.Modules.Stores.Domain.DomainEvents;

public class StoreCreatedEvent(Store store) : IDomainEvent
{
    public Guid Id { get; private set; } = store!.Id;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    private Store Store { get; } = store;
}