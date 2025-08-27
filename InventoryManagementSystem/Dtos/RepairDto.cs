using InventoryManagementSystem.Enums;

namespace InventoryManagementSystem.Dtos;

public class MaintenanceDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public MaintenanceStatus Status { get; set; }
}
