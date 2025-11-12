using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Catalogs.Domain.Entities;

namespace Hababk.Modules.Catalogs.Domain.DomainEvents;

public class CatalogCreatedEvent(Catalog catalog) : IDomainEvent
{
    public Guid Id { get; } = catalog.Id;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public Catalog Catalog { get; set; } = catalog;
}