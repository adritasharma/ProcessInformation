using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class technology1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "TechnologiesUsed",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationTypeDescription",
                table: "ApplicationType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationTypeDescription",
                table: "ApplicationType");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationTypeId",
                table: "Application",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TechnologiesUsed",
                table: "Application",
                nullable: true);
        }
    }
}
