using Dapper;
using Hababk.Modules.Catalogs.Application.Dtos;
using Npgsql;

namespace Hababk.Modules.Catalogs.Application.Queries;

public class CatalogQueries(string connectionString) : ICatalogQueries
{
    private readonly string _connectionString = connectionString;
    public async Task<IQueryable<CatalogDto>> GetListAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<CatalogDto>("SELECT * FROM Catalogs");
        return result.AsQueryable();
    }
    public Task<CatalogDto?> GetByIdAsync(Guid id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = connection.QueryFirstOrDefaultAsync<CatalogDto>("SELECT * FROM Catalogs WHERE Id=@Id",new {Id = id});
        return result;
    }
}