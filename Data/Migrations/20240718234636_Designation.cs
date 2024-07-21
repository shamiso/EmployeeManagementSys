using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class Designation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desination",
                table: "Employees",
                newName: "Designation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Employees",
                newName: "Desination");
        }
    }
}
