using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActivityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "SystemCodes");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "SystemCodeDetails");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Banks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "SystemCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "SystemCodeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "LeaveTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
