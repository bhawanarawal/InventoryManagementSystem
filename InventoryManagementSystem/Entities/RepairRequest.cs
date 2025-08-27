using InventoryManagementSystem.Enums;

namespace InventoryManagementSystem.Entities;

public class RepairRequest : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public MaintenanceStatus Status { get; set; } 

}
