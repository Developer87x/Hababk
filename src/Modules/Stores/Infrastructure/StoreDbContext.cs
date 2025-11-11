using Domain.ValueObjects;
using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Stores.Domain.Entities;
using Hababk.Modules.Stores.Infrastructure.Configurations.EntityTypedConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hababk.Modules.Stores.Infrastructure;

public class StoreDbContext:DbContext,IUnitOfWork
{
    private readonly IMediator _mediator;
    public const string DefaultSchema = "Store";
    public DbSet<Store> Stores { get; set; }
    public DbSet<Contact> Contacts { get; set; }
   
    public StoreDbContext(DbContextOptions<StoreDbContext> options,IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
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
        base.OnModelCreating(modelBuilder);
    }
}