using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirConditionersManagementSystem.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TechnicianId",
                table: "Requests",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_TechnicianId",
                table: "Requests",
                column: "TechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_TechnicianId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TechnicianId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "Requests");
        }
    }
}
