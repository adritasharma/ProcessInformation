using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class AT5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "Application");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationTypeId",
                table: "Application",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    ApplicationTypeId = table.Column<Guid>(nullable: false),
                    ApplicationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.ApplicationTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationType",
                table: "Application",
                nullable: true);
        }
    }
}
