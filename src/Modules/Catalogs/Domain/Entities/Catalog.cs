using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Catalogs.Domain.DomainEvents;

namespace Hababk.Modules.Catalogs.Domain.Entities;

public class Catalog :Entity,IAggregateRoot
{
    private Catalog(Guid id, CatalogType? catalogType, string? catalogName, string? description, decimal price, string storeId) : base(id)
    {
        CatalogType = catalogType;
        CatalogName = catalogName;
        Description = description;
        Price = price;
        StoreId = storeId;
        this.AddDomainEvent(new CatalogCreatedEvent(this));
    }
    public string? CatalogName { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string StoreId { get; private set; }
    public Guid CatalogId { get; private set; }
    public CatalogType? CatalogType { get; private set; }

    public static Catalog Create(Guid id, CatalogType? catalogType, string? catalogName, string? description, decimal price,string storeId)
    {
        return new Catalog(id, catalogType, catalogName, description, price,storeId);
    }
    
    
    
}