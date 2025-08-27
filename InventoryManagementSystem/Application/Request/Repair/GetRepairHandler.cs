using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services;


namespace InventoryManagementSystem.Application.Request.Repair;

public static class GetRepairHandler
{
    public static async Task<IResult> HandleAsync(IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "SELECT * from Repair";
        var result = await databaseService.GetAllQueryAsync<RepairDto>(cancellationToken: cancellationToken, query:query);


        return Results.Ok(result);



    }
    //public static async Task<IResult> HandleByIdAsync(int id, ApplicationDbContext db, CancellationToken cancellationToken = default)
    //{
    //    var maintenanceRequest = await db.Maintenance.Select(x => new MaintenanceDto()
    //    {
    //        Id = x.Id,
    //        Description = x.Description
    //        // Map other properties as needed
    //    }).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    //    if (maintenanceRequest == null)
    //    {
    //        return Results.NotFound(new { Message = "Maintenance request not found" });
    //    }
    //    return Results.Ok(maintenanceRequest);
    //}

    public static async Task<IResult> HandleByIdAsync(int id, IDatabaseService databaseService, CancellationToken cancellationToken = default)
    {
        var query = "SELECT * FROM Repair WHERE Id = @Id";
        var parameters = new { Id = id };

        var result = await databaseService.GetQueryAsync<RepairDto>(query, parameters, cancellationToken: cancellationToken);

        if (result == null)
        {
            return Results.NotFound(new { Message = "Repair request not found" });
        }

        return Results.Ok(result);
    }

}