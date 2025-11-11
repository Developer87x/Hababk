using Domain.ValueObjects;
using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.DomainEvents;

namespace Hababk.Modules.Stores.Domain.Entities;

public class Store :Entity,IAggregateRoot
{
    private Store(Guid id,string storeName,string? description ,string userId) : base(id)
    {
        StoreName = storeName;
        UserId = userId;
        Description = description;
        this.AddDomainEvent(new StoreCreatedEvent(this));
    } 
    public string? StoreName { get; private set; }
    public string? Description { get; private set; }
    public string UserId { get; private set; }
    public Contact Contact { get; private set; }
    public static Store Create(string storeName,string? description,string userId) => new(Guid.NewGuid(),storeName,description,userId);
    
    public override string? ToString() => StoreName;

    public void Update(string storeName)
    {
        StoreName = storeName;
        this.AddDomainEvent(new StoreUpdatedEvent(this));
    }
}