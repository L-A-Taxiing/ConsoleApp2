using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class Add_User_SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Register_InvitedById",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_InvitedById",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "FailedTry",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "InvitedById",
                table: "Register");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Register",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Register",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "InvitedByName",
                table: "Register",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Register_CreateTime",
                table: "Register",
                column: "CreateTime",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Register_InvitedByName",
                table: "Register",
                column: "InvitedByName");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CreateTime",
                table: "Register",
                sql: "CreateTime>2020-1-1");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Register_InvitedByName",
                table: "Register",
                column: "InvitedByName",
                principalTable: "Register",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Register_InvitedByName",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_CreateTime",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_InvitedByName",
                table: "Register");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CreateTime",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "InvitedByName",
                table: "Register");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Register",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Register",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "FailedTry",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvitedById",
                table: "Register",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Register_InvitedById",
                table: "Register",
                column: "InvitedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Register_InvitedById",
                table: "Register",
                column: "InvitedById",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
