using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Application.Request.Repair;

public static class CreateRepairHandler
{
    public static async Task<IResult> HandleAsync(RepairRequest request, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "INSERT INTO Repair (Description, Status, CreatedAt, UpdatedAt) " +
            "VALUES (@Description, @Status, GETUTCDATE(), GETUTCDATE());SELECT CAST(SCOPE_IDENTITY() as int);";

        var parameters = new
        {
            request.Description,
            Status = (int)request.Status // store enum as int
        };

        var newId = await databaseService.ExecuteScalarAsync<int>(query, parameters, cancellationToken);

        return Results.Created($"/Repair/{newId}", new { Message = "Repair created", Id = newId });
    }
}

