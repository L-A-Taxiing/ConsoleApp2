using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class User_And_Email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailAddressId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailAddressId",
                table: "User",
                column: "EmailAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Email_EmailAddressId",
                table: "User",
                column: "EmailAddressId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Email_EmailAddressId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropIndex(
                name: "IX_User_EmailAddressId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmailAddressId",
                table: "User");
        }
    }
}
