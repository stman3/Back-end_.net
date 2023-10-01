using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_alpha.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalIdentity",
                table: "Employees",
                column: "NationalIdentity",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalIdentity",
                table: "Employees");
        }
    }
}
