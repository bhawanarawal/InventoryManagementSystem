using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services;
public static class UpdateRepairHandler
{
    public static async Task<IResult> HandleAsync(int id, RepairDto request, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "UPDATE Repair SET Description = @Description, Status = @Status, UpdatedAt = GETUTCDATE() WHERE Id = @Id";

        var parameters = new
        {
            Id = id,
            request.Description,
            request.Status
        };

        var rowsAffected = await databaseService.ExecuteAsync(query, parameters, cancellationToken);

        if (rowsAffected == 0)
            return Results.NotFound(new { Message = $"No repair found with ID = {id}" });

        return Results.Ok(new { Message = "Repair updated successfully" });
    }
}
