using Hababk.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Catalogs.Infrastructure;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options, IMediator mediator) : DbContext(options) , IUnitOfWork
{
    private const string DefaultSchema = "Catalog";
    private readonly IMediator _mediator = mediator;

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}