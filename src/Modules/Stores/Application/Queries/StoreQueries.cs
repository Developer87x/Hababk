using Dapper;
using Hababk.Modules.Stores.Application.Models;
using Npgsql;

namespace Hababk.Modules.Stores.Application.Queries;

public class StoreQueries(string? connectionString) : IStoreQueries
{
    private readonly string _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

    public async Task<StoreDto> GetByIdAsync(Guid id)
    {
        await using var connection =  new NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<StoreDto>($"SELECT * FROM \"Store\".\"Stores\" WHERE Id=@Id",new {Id = id});
        return result.FirstOrDefault()!;
    }

    public async Task<List<StoreDto?>> GetListAsync()
    {
        await using var connection =  new NpgsqlConnection(_connectionString); 
        await connection.OpenAsync();
       var result = await connection.QueryAsync<StoreDto, ContactDto,StoreDto>(sql: """
                 SELECT * FROM "store"."stores" as st
                join "store"."contacts" as ct on st."Id"= ct."StoreId"
           """,(store,contact)=>
       {
           store.Contact=contact;
           return store;
       },splitOn: "StoreId");
       return result.ToList()!;
    }
    
    
}