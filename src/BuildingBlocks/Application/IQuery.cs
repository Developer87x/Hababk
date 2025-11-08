namespace Hababk.BuildingBlocks.Application;

public interface IQuery<TResult>
{
    Task<IQueryable<TResult>> GetListAsync();
    Task<TResult?> GetByIdAsync(Guid id);    
}


