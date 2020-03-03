using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class technology2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationTypeId",
                table: "Application",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application",
                column: "ApplicationTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationType_ApplicationTypeId",
                table: "Application",
                column: "ApplicationTypeId",
                principalTable: "ApplicationType",
                principalColumn: "ApplicationTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationType_ApplicationTypeId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeId",
                table: "Application");
        }
    }
}
