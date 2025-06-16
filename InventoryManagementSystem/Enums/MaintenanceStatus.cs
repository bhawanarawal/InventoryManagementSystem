namespace InventoryManagementSystem.Enums;

public enum MaintenanceStatus
{
    Pending=1,   // Maintenance request is pending
    InProgress, // Maintenance is currently being performed
    Completed,  // Maintenance has been completed
    Cancelled   // Maintenance request has been cancelled
}
