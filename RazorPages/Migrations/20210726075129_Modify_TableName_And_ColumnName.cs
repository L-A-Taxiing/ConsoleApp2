using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RazorPages.Migrations
{
    public partial class Modify_TableName_And_ColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_InvitedById",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Register");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Register",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_User_InvitedById",
                table: "Register",
                newName: "IX_Register_InvitedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Register",
                table: "Register",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Register_InvitedById",
                table: "Register",
                column: "InvitedById",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Register_InvitedById",
                table: "Register");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Register",
                table: "Register");

            migrationBuilder.RenameTable(
                name: "Register",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Register_InvitedById",
                table: "User",
                newName: "IX_User_InvitedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_InvitedById",
                table: "User",
                column: "InvitedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
