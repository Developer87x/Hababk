using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Catalogs.Domain.Entities;

namespace Hababk.Modules.Catalogs.Application.Commands;

public class CreateCatalogCommand :ICommand<bool>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public CatalogType? CatalogType { get; set; }
}