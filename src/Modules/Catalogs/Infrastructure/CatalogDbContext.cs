using Hababk.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Catalogs.Infrastructure;

public class CatalogDbContext :DbContext,IUnitOfWork
{
    private const string DefaultSchema = "Catalog";
    private readonly IMediator _mediator;
    
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options,IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}