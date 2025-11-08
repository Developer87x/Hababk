using Dapper;
using Hababk.Modules.Stores.Application.Models;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Hababk.Modules.Stores.Application.Queries;

public class StoreQueries : IStoreQueries
{
    private readonly string _connectionString;

    public StoreQueries(string? connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<StoreDto?> GetByIdAsync(Guid id)
    {
        await using var connection =  new SqlConnection(_connectionString);
        connection.Open();
        var result = connection.QueryAsync<StoreDto>($"SELECT * FROM Stores WHERE Id=@Id",new {Id = id});
        return result.Result.FirstOrDefault();
    }

    public async Task<IQueryable<StoreDto>> GetListAsync()
    {
        await using var connection =  new NpgsqlConnection(_connectionString); 
        await connection.OpenAsync();
       var result = await connection.QueryAsync<StoreDto>(sql: "SELECT * FROM \"Store\".\"Stores\"");
       return result.AsQueryable();
    }
    
    
}