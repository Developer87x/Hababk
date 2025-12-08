namespace Hababk.Modules.Catalogs.Application.Models;

public class CatalogDto
{
    public string? CatalogName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public CatalogTypeDto? CatalogType { get; set; }

}
