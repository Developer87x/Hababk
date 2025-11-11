using Dapper;
using Hababk.Modules.Stores.Application.Models;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Hababk.Modules.Stores.Application.Queries;

public class StoreQueries(string? connectionString) : IStoreQueries
{
    private readonly string _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

    public async Task<StoreDto?> GetByIdAsync(Guid id)
    {
        await using var connection =  new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = connection.QueryAsync<StoreDto>($"SELECT * FROM \"Store\".\"Stores\" WHERE Id=@Id",new {Id = id});
        return result.Result.FirstOrDefault();
    }

    public async Task<IQueryable<StoreDto>> GetListAsync()
    {
        await using var connection =  new NpgsqlConnection(_connectionString); 
        await connection.OpenAsync();
       var result = await connection.QueryAsync<StoreDto>(sql: @"
      SELECT * FROM ""Store"".""Stores"" as st
     join ""Store"".""Contacts"" as ct on st.""Id""= ct.""StoreId""");
       return result.AsQueryable();
    }
    
    
}