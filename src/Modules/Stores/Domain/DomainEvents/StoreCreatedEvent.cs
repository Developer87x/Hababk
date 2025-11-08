using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;

namespace Hababk.Modules.Stores.Domain.DomainEvents;

public class StoreCreatedEvent :IDomainEvent
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private Store Store { get;  }
    public StoreCreatedEvent(Store store)
    {
        Id = store!.Id;
        CreatedAt =DateTime.UtcNow; 
        Store = store;
    }
}