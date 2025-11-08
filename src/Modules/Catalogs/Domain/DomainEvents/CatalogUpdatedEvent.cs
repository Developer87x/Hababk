using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Catalogs.Domain.DomainEvents;

public class CatalogUpdatedEvent : IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
}