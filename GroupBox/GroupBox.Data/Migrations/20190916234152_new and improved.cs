using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupBox.Data.Migrations
{
    public partial class newandimproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_UserID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Groups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserID",
                table: "Groups",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_UserID",
                table: "Groups",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
