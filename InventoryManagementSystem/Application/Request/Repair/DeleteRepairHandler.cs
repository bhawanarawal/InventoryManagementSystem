using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Application.Request.Repair;

public static class DeleteRepairHandler
{
    public static async Task<IResult> HandleByIdAsync(int id, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "DELETE FROM Repair WHERE Id = @Id";

        var parameters = new { Id = id };

        var rowsAffected = await databaseService.ExecuteNonQuerAsync(query, parameters, cancellationToken);

        if (rowsAffected == 0)
        {
            return Results.NotFound(new { Message = $"Repair with ID {id} not found." });
        }

        return Results.Ok(new { Message = "Repair deleted successfully." });
    }
}
