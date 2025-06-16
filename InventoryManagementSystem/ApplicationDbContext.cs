
using InventoryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Application.DataContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<MaintenanceRequest> Maintenance { get; set; } 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
