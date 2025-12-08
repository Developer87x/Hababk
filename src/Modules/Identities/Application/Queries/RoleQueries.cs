using Dapper;
using Hababk.Modules.Identities.Application.Models;

namespace Hababk.Modules.Identities.Application.Queries;

public class RoleQueries (string connectionString) : IRoleQueries
{

    private readonly string _connectionString= connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    public async Task<RoleDto?> GetRoleByNameAsync(string roleName)
    {
        await using var connection = new Npgsql.NpgsqlConnection(_connectionString);
        const string sql = "Select * from \"identity\".\"roles\" WHERE \"roleName\"=@role";
        var role =  await connection.QuerySingleOrDefaultAsync<RoleDto>(sql, new { role = roleName });
        return role;
    }

    public Task<bool> RoleExistsAsync(string roleName)
    {
        throw new NotImplementedException();
    }
}