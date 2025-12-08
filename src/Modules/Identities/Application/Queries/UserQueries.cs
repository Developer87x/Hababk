using Dapper;
using Hababk.Modules.Identities.Application.Models;

namespace Hababk.Modules.Identities.Application.Queries;

public class UserQueries(string? connectionString) : IUserQueries
{
    private readonly string _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        await using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<UserDto>(sql: $"SELECT \"userName\",email FROM \"identity\".\"users\" WHERE \"Id\"=@Id", new { Id = id });
        return result.FirstOrDefault()!;
    }

    public async Task<UserDto?> GetByUserNameAsync(string username)
    {
        await using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<UserDto>(sql: $"SELECT * FROM \"identity\".\"users\" WHERE \"userName\"=@user", param: new { user = username });
        return result.FirstOrDefault();
    }

    public async Task<List<UserDto?>> GetListAsync()
    {
        await using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        connection.Open();
        var result = await connection.QueryAsync<UserDto>(sql: $"SELECT * FROM \"identity\".\"users\"");
        return result.ToList()!;
    }
}