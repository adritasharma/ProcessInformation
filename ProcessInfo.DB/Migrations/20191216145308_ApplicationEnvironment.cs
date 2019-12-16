using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class ApplicationEnvironment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppPool",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ConfigFiles",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "Database",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "EnvironmentId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "IISInstance",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ServerPath",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "SiteUrl",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "VersionControlPath",
                table: "Application");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationId",
                table: "Application",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "Application",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AppPool",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfigFiles",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Database",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnvironmentId",
                table: "Application",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IISInstance",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServerPath",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteUrl",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VersionControlPath",
                table: "Application",
                nullable: true);
        }
    }
}
