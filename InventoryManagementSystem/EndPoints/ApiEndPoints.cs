using InventoryManagementSystem.Application.DataContext;
using InventoryManagementSystem.Application.Request.Maintenance;
using InventoryManagementSystem.Application.Request.Repair;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace InventoryManagementSystem.EndPoints;

public static class ApiEndPoints
{
    public static RouteGroupBuilder MapApiEndpoints(this RouteGroupBuilder app)
    {
        app.MapGroup("/maintenance")
            .WithTags("Maintenance Api")
            .WithOpenApi()
            .RequireAuthorization()
            .MapMaintenanceEndpoints();

        app.MapGroup("/repair")
           .WithTags("Repair API")
           .WithOpenApi()
           .RequireAuthorization()
           .MapRepairEndpoints();

        return app;
    }
    private static void MapMaintenanceEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/", GetMaintenanceHandler.HandleAsync);
        app.MapGet("/{id:int}", (int id, IDatabaseService databaseService, CancellationToken cancellationToken) =>
            GetMaintenanceHandler.HandleByIdAsync(id, databaseService, cancellationToken));
        app.MapPost("/", CreateMaintenanceHandler.HandleAsync);
        app.MapPut("/{id:int}", (int id, MaintenanceDto request, IDatabaseService databaseService, CancellationToken cancellationToken) =>
            UpdateMaintenaceHandler.HandleAsync(id, request, databaseService, cancellationToken));
        app.MapDelete("/{id:int}", (int id, IDatabaseService databaseService, CancellationToken cancellationToken) =>
            DeleteMaintenanceHandler.HandleByIdAsync(id, databaseService, cancellationToken));
    }

    private static void MapRepairEndpoints(this RouteGroupBuilder app)
    {
        app.MapGet("/",GetRepairHandler.HandleAsync);
        app.MapGet("/{id:int}", (int id, IDatabaseService databaseService, CancellationToken cancellationToken) =>
            GetRepairHandler.HandleByIdAsync(id, databaseService, cancellationToken));
        app.MapPost("/", CreateRepairHandler.HandleAsync);
        app.MapPut("/{id:int}", (int id, RepairDto request,IDatabaseService databaseService, CancellationToken cancellationToken) =>
            UpdateRepairHandler.HandleAsync(id,request, databaseService, cancellationToken));
        app.MapDelete("/{id:int}", (int id, IDatabaseService databaseService, CancellationToken cancellationToken) =>
            DeleteRepairHandler.HandleByIdAsync(id, databaseService, cancellationToken));
    }
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", (LoginRequest loginRequest, JwtTokenService jwtService) =>
        {
            
            if (loginRequest.Email == "user@example.com" && loginRequest.Password == "password")
            {
                var token = jwtService.GenerateToken(loginRequest.Email);
                return Results.Ok(new { Token = token });
            }
            return Results.Unauthorized();
        });
    }
}