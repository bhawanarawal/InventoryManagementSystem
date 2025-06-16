using InventoryManagementSystem.Application.DataContext;
using InventoryManagementSystem.Application.Request.Maintenance;

namespace InventoryManagementSystem.EndPoints;

public static class ApiEndPoints
{
    public static RouteGroupBuilder MapApiEndpoints(this RouteGroupBuilder app)
    {
        app.MapGroup("/maintenance")
            .WithTags("Maintenance Api")
            .WithOpenApi()
        .MapMaintenanceEndpoints();
        return app;
    }
    private static void MapMaintenanceEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/", GetMaintenanceHandler.HandleAsync);
        app.MapGet("/{id:int}", (int id,ApplicationDbContext db,CancellationToken cancellationToken) => GetMaintenanceHandler.HandleByIdAsync(id, db, cancellationToken));
        app.MapPost("/", CreateMaintenanceHandler.HandleAsync);
        app.MapPut("/", UpdateMaintenanceHandler.HandleAsync);

    }
}