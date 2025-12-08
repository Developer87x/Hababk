using Dapper;
using Hababk.Modules.Catalogs.Application.Models;
using Npgsql;

namespace Hababk.Modules.Catalogs.Application.Queries;

public class CatalogQueries(string connectionString) : ICatalogQueries
{
    private readonly string _connectionString = connectionString;
    public async Task<List<CatalogDto?>> GetListAsync()
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<CatalogDto>("SELECT * FROM Catalogs");
        var list = result.ToList();
        return (list?? throw new Exception("No Catalogs"))!;
    }
    public Task<CatalogDto> GetByIdAsync(Guid id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = connection.QueryFirstOrDefaultAsync<CatalogDto>("SELECT * FROM Catalogs WHERE Id=@Id",new {Id = id});
        return result!;
    }
}