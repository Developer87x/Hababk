using Hababk.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure;

public class IdentitiesDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    private const string Schema = "Identity";

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
}
