using Application.Dtos;
using Dapper;

namespace Hababk.Modules.Identities.Application.Queries;

public class RoleQueries (string connectionString) : IRoleQueries
{

    private readonly string _connectionString= connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    public async Task<RoleDto?> GetRoleByNameAsync(string roleName)
    {
        using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        const string sql = "Select * from \"identity\".\"roles\" WHERE \"roleName\"=@roleName";
        var role =  await connection.QuerySingleOrDefaultAsync<RoleDto>(sql, new { roleName = roleName });
        return role;
    }

    public Task<bool> RoleExistsAsync(string roleName)
    {
        throw new NotImplementedException();
    }
}