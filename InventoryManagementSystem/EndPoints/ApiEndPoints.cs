using InventoryManagementSystem.Application.Request.Maintenance;

namespace InventoryManagementSystem.EndPoints
{
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
            app.MapPost("/", CreateMaintenanceHandler.HandleAsync);
        }
    }
}