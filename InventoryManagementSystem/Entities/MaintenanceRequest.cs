using InventoryManagementSystem.Enums;

namespace InventoryManagementSystem.Entities;

public class MaintenanceRequest : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public MaintenanceStatus Status { get; set; } 

}
