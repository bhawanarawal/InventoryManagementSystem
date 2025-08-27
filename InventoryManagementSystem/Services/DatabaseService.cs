using Dapper;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Services;

public class DatabaseService : IDatabaseService
{
    private readonly IConfiguration _configuration;

    public DatabaseService(IConfiguration configuration)
    {
        _configuration= configuration;

    }
    public async Task<List<T>> GetAllQueryAsync<T>(string query, CancellationToken cancellationToken = default)
    {
        using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {

            await db.OpenAsync(cancellationToken);


            var results = await db.QueryAsync<T>(query, cancellationToken);
            return results.ToList();
        }
    }

    public async Task<T?> GetQueryAsync<T>(string query, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            await db.OpenAsync(cancellationToken);

            // Dapper does not support CancellationToken directly
            var result = await db.QueryFirstOrDefaultAsync<T>(query, parameters);

            return result;
        }
    }
    public async Task<T?> ExecuteScalarAsync<T>(string query, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            await db.OpenAsync(cancellationToken);
            var result = await db.ExecuteScalarAsync<T>(query, parameters);
            return result;
        }
    }
  

    public async Task<int> ExecuteNonQueryAsync(string query, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using (var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            await db.OpenAsync(cancellationToken);
           
            return await db.ExecuteAsync(query, parameters);
        }
    }

    public async Task<int> ExecuteNonQuerAsync(string query, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await db.OpenAsync(cancellationToken);

        var command = new CommandDefinition(query, parameters, cancellationToken: cancellationToken);
        return await db.ExecuteAsync(command);
    }

    public async Task<int> ExecuteAsync(string sql, object parameters, CancellationToken cancellationToken = default)
    {
        using var db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await db.OpenAsync(cancellationToken);

        var command = new CommandDefinition(sql, parameters, cancellationToken: cancellationToken);
        return await db.ExecuteAsync(command);
    }

}
