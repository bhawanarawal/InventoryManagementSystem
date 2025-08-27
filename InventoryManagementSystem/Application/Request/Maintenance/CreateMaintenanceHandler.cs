using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Application.Request.Maintenance;

public static class CreateMaintenanceHandler
{
    public static async Task<IResult> HandleAsync(MaintenanceRequest request, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "INSERT INTO Maintenance (Description, Status, CreatedAt, UpdatedAt) " +
            "VALUES (@Description, @Status, GETUTCDATE(), GETUTCDATE());SELECT CAST(SCOPE_IDENTITY() as int);";

        var parameters = new
        {
            request.Description,
            Status = (int)request.Status // store enum as int
        };

        var newId = await databaseService.ExecuteScalarAsync<int>(query, parameters, cancellationToken);

        return Results.Created($"/maintenance/{newId}", new { Message = "Maintenance created", Id = newId });
    }
}

