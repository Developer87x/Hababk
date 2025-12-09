
using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;
using Hababk.Modules.Stores.Infrastructure.Configurations.EntityTypedConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Stores.Infrastructure;

public class StoreDbContext(DbContextOptions<StoreDbContext> options, IMediator mediator) : DbContext(options),IUnitOfWork
{
    private readonly IMediator _mediator = mediator;
    public const string DefaultSchema = "store";
    public DbSet<Store> Stores { get; set; }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = this.ChangeTracker.Entries<Entity>().Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();
        var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents!).ToList();

        domainEntities.ForEach(x => x.Entity.ClearDomainEvents());
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        return await base.SaveChangesAsync(cancellationToken) > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StoreEntityTypedConfiguration());
        
       
    }
   
}