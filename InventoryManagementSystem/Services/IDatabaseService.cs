
namespace InventoryManagementSystem.Services
{
    public interface IDatabaseService
    {
        Task<List<T>> GetAllQueryAsync<T>(string query, CancellationToken cancellationToken = default);
        Task<T?> GetQueryAsync<T>(string query, object? parameters = null, CancellationToken cancellationToken = default);
        Task<T?> ExecuteScalarAsync<T>(string query, object? parameters = null, CancellationToken cancellationToken = default);
       

        Task<int> ExecuteNonQuerAsync(string query, object? parameters = null, CancellationToken cancellationToken = default);
        Task<int> ExecuteAsync(string sql, object parameters, CancellationToken cancellationToken = default);

    }

}