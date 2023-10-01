using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_alpha.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId1",
                table: "Tasks",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId1",
                table: "Tasks",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
