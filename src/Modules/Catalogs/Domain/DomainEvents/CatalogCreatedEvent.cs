using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Catalogs.Domain.Entities;

namespace Hababk.Modules.Catalogs.Domain.DomainEvents;

public class CatalogCreatedEvent :IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public Catalog Catalog { get; set; }

    public CatalogCreatedEvent(Catalog catalog)
    {
        Id = catalog.Id;
        CreatedAt = DateTime.UtcNow;
        Catalog = catalog;
    }
}