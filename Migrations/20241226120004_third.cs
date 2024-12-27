using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentNameId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentNameId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentNameId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentNameId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentNameId",
                table: "Employees",
                column: "DepartmentNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentNameId",
                table: "Employees",
                column: "DepartmentNameId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
