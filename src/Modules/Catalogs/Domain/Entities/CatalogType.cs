using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Catalogs.Domain.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class CatalogType : Enumeration
{
    public CatalogType(Guid id, string value) : base(id, value)
    {
    }
}