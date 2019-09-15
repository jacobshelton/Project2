using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupBox.Data.Migrations
{
    public partial class tookoutpasswordstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passwords_PasswordID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PasswordID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordID",
                table: "Users",
                column: "PasswordID");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_Hash",
                table: "Passwords",
                column: "Hash",
                unique: true,
                filter: "[Hash] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passwords_PasswordID",
                table: "Users",
                column: "PasswordID",
                principalTable: "Passwords",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
