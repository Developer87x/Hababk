using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.Entities;
using Infrastructure.Configurations.EntityTypedConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure;

public class IdentitiesDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public const string Schema = "Identity";
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public IdentitiesDbContext(DbContextOptions<IdentitiesDbContext> options, IMediator mediator) : base(options)
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
        modelBuilder.ApplyConfiguration(new UserEntityTypedConfigurations());
    }
}
