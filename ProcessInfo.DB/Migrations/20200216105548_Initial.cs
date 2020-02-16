using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ApplicationName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    WorkObjectName = table.Column<int>(nullable: false),
                    TeamMembers = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
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

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEnvironment",
                columns: table => new
                {
                    ApplicationEnvironmentId = table.Column<Guid>(nullable: false),
                    ServerPath = table.Column<string>(nullable: true),
                    AppPool = table.Column<string>(nullable: true),
                    IISInstance = table.Column<string>(nullable: true),
                    VersionControlPath = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    ConfigFiles = table.Column<string>(nullable: true),
                    Database = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_ApplicationEnvironment_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEnvironment_ApplicationId",
                table: "ApplicationEnvironment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEnvironment_EnvironmentId",
                table: "ApplicationEnvironment",
                column: "EnvironmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationEnvironment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Environment");
        }
    }
}
