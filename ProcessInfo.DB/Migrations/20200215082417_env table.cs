using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class envtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationEnvironment",
                columns: table => new
                {
                    ApplicationEnvironmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnvironmentId = table.Column<int>(nullable: false),
                    ServerPath = table.Column<string>(nullable: true),
                    AppPool = table.Column<string>(nullable: true),
                    IISInstance = table.Column<string>(nullable: true),
                    VersionControlPath = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    ConfigFiles = table.Column<string>(nullable: true),
                    Database = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEnvironment", x => x.ApplicationEnvironmentId);
                    table.ForeignKey(
                        name: "FK_ApplicationEnvironment_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    EnvironmentName = table.Column<string>(nullable: true),
                    EnvironmentDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.EnvironmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEnvironment_ApplicationId",
                table: "ApplicationEnvironment",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationEnvironment");

            migrationBuilder.DropTable(
                name: "Environment");
        }
    }
}
