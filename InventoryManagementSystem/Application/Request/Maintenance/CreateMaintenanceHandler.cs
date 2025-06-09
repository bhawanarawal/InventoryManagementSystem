using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Application.Request.Maintenance
{
    public static class CreateMaintenanceHandler
    {
        public static async Task<IResult> HandleAsync(CreateMaintenance request, CancellationToken cancellationToken = default)
        {
            // Simulate creating maintenance data
            await Task.Delay(1000, cancellationToken); // Simulating async operation

            // For now, return a dummy response with the received request data
            return Results.Created($"/maintenance/{request.Id}", new
            {
                Message = "Maintenance created successfully",
                Data = request
            });
        }
    }
}
