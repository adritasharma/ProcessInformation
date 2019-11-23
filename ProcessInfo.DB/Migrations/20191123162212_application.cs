using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class application : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    WorkObjectName = table.Column<int>(nullable: false),
                    TeamMembers = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<string>(nullable: true),
                    EnvironmentId = table.Column<int>(nullable: false),
                    ServerPath = table.Column<string>(nullable: true),
                    AppPool = table.Column<string>(nullable: true),
                    IISInstance = table.Column<string>(nullable: true),
                    VersionControlPath = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    ConfigFiles = table.Column<string>(nullable: true),
                    Database = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
