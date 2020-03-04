using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessInfo.DB.Migrations
{
    public partial class apptypecollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application",
                column: "ApplicationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationTypeId",
                table: "Application",
                column: "ApplicationTypeId",
                unique: true);
        }
    }
}
