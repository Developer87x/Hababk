namespace Hababk.BuildingBlocks.Application;

public interface IQuery<TResult>
{
    Task<List<TResult?>>GetListAsync();
    Task<TResult>GetByIdAsync(Guid id);    
}


