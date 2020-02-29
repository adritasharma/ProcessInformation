using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class Appdeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamMembers",
                table: "Application");

            migrationBuilder.CreateTable(
                name: "ApplicationDevelopers",
                columns: table => new
                {
                    ApplicationDeveloperId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDevelopers", x => x.ApplicationDeveloperId);
                    table.ForeignKey(
                        name: "FK_ApplicationDevelopers_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDevelopers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDevelopers_ApplicationId",
                table: "ApplicationDevelopers",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDevelopers_UserId",
                table: "ApplicationDevelopers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDevelopers");

            migrationBuilder.AddColumn<string>(
                name: "TeamMembers",
                table: "Application",
                nullable: true);
        }
    }
}
