using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeKnockOut.Migrations
{
    /// <inheritdoc />
    public partial class GenderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "EmployeeModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EmployeeModel");
        }
    }
}
