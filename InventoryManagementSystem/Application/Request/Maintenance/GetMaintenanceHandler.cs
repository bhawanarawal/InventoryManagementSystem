using InventoryManagementSystem.Application.DataContext;
using InventoryManagementSystem.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Application.Request.Maintenance;

public static class GetMaintenanceHandler
{
    public static async Task<IResult> HandleAsync(ApplicationDbContext db, CancellationToken cancellationToken = default)
    {
        var maintenanaceRequests = await db.Maintenance.ToListAsync(cancellationToken);


        return Results.Ok(maintenanaceRequests);



    }
//    public static async Task<IResult> HandleByIdAsync(int id, ApplicationDbContext db, CancellationToken cancellationToken = default)
//    {
//        var maintenanceRequest = await db.Maintenance.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
//        return Results.Ok(maintenanceRequest);

//    }
//}
    public static async Task<IResult> HandleByIdAsync(int id, ApplicationDbContext db, CancellationToken cancellationToken = default)
    {
        var maintenanceRequest = await db.Maintenance.Select(x => new MaintenanceDto()
        {
            Id = x.Id,
            Description = x.Description
            // Map other properties as needed
        }).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        if (maintenanceRequest == null)
        {
            return Results.NotFound(new { Message = "Maintenance request not found" });
        }
        return Results.Ok(maintenanceRequest);
    }
}
