using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;

namespace Hababk.Modules.Stores.Domain.DomainEvents;

public class StoreUpdatedEvent : IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    private Store Store { get; }
    public StoreUpdatedEvent(Store store) 
    {
        Id = Store!.Id;
        CreatedAt =DateTime.UtcNow; 
        Store = store;
    }
}