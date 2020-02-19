using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class Portfieldinenv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Port",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "Port",
                table: "ApplicationEnvironment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Port",
                table: "ApplicationEnvironment");

            migrationBuilder.AddColumn<string>(
                name: "Port",
                table: "Application",
                nullable: true);
        }
    }
}
