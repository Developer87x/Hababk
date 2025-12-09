namespace Hababk.BuildingBlocks.Domain;

public interface IRepository<out T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}