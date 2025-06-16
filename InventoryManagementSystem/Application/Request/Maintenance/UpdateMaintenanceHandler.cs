using InventoryManagementSystem.Application.DataContext;
using InventoryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagementSystem.Application.Request.Maintenance;

public static class UpdateMaintenanceHandler
{
    public static async Task<IResult> HandleAsync(MaintenanceRequest request, ApplicationDbContext db, CancellationToken cancellationToken = default)
    {
        db.Update(request);
        await db.SaveChangesAsync();

        
        return Results.NoContent();
    }
}
