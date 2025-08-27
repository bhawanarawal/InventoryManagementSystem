using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameRepairRequestsToRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairRequests",
                table: "RepairRequests");

            migrationBuilder.RenameTable(
                name: "RepairRequests",
                newName: "Repair");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repair",
                table: "Repair",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Repair",
                table: "Repair");

            migrationBuilder.RenameTable(
                name: "Repair",
                newName: "RepairRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairRequests",
                table: "RepairRequests",
                column: "Id");
        }
    }
}
