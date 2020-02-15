using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class guidenv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EnvironmentId",
                table: "ApplicationEnvironment",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EnvironmentId",
                table: "ApplicationEnvironment",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
