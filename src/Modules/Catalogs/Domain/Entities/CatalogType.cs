using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Catalogs.Domain.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class CatalogType(Guid id, string value) : Enumeration(id, value)
{
}