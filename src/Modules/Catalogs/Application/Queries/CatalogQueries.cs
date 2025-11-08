using System.Data.SqlClient;
using Dapper;
using Hababk.Modules.Catalogs.Application.Dtos;

namespace Hababk.Modules.Catalogs.Application.Queries;

public class CatalogQueries : ICatalogQueries
{
    
    private readonly string _connectionString;

    public CatalogQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IQueryable<CatalogDto>> GetListAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<CatalogDto>("SELECT * FROM Catalogs");
        return result.AsQueryable();
    }

    public Task<CatalogDto?> GetByIdAsync(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var result = connection.QueryFirstOrDefaultAsync<CatalogDto>("SELECT * FROM Catalogs WHERE Id=@Id",new {Id = id});
        return result;
    }
}