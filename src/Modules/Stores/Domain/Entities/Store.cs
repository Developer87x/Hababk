using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.DomainEvents;
using Hababk.Modules.Stores.Domain.ValueObjects;

namespace Hababk.Modules.Stores.Domain.Entities;

public class Store :Entity,IAggregateRoot
{
    protected Store(Guid id,string storeName,string? description ,string userId, Contact contact) : base(id)
    {
        StoreName = storeName;
        UserId = userId;
        Description = description;
        Contact = contact;
        this.AddDomainEvent(new StoreCreatedEvent(this));
    } 
    public string? StoreName { get; private set; }
    public string? Description { get; private set; }
    public string UserId { get; private set; }
    public Contact? Contact { get; private set; }
    public static Store Create(string storeName,string? description,string userId,string email,string phoneNumber) 
        => new(Guid.NewGuid(),storeName,description,userId,new Contact(email,phoneNumber));
    
    public override string? ToString() => StoreName;

    public void Update(string storeName)
    {
        StoreName = storeName;
        this.AddDomainEvent(new StoreUpdatedEvent(this));
    }
}