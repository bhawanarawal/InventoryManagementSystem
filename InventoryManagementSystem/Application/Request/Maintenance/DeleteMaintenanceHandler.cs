using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Application.Request.Maintenance;

public static class DeleteMaintenanceHandler
{
    public static async Task<IResult> HandleByIdAsync(int id, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "DELETE FROM Maintenance WHERE Id = @Id";

        var parameters = new { Id = id };

        var rowsAffected = await databaseService.ExecuteNonQuerAsync(query, parameters, cancellationToken);

        if (rowsAffected == 0)
        {
            return Results.NotFound(new { Message = $"Maintenance with ID {id} not found." });
        }

        return Results.Ok(new { Message = "Maintenance deleted successfully." });
    }
}
