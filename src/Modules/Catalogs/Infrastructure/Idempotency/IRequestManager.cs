namespace Hababk.Modules.Catalogs.Infrastructure.Idempotency; 

public interface IRequestManager
{
    Task<bool> IsExistAsync(Guid id);
    Task CreateRequestForCommandAsync<T>(Guid id);
}