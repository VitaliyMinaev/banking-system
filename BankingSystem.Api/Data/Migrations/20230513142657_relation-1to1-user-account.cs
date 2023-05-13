using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class relation1to1useraccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_ApplicationUsers_OwnerId",
                table: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_OwnerId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountId",
                table: "ApplicationUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_BankAccountId",
                table: "ApplicationUsers",
                column: "BankAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_BankAccounts_BankAccountId",
                table: "ApplicationUsers",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_BankAccounts_BankAccountId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_BankAccountId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "BankAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_OwnerId",
                table: "BankAccounts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_ApplicationUsers_OwnerId",
                table: "BankAccounts",
                column: "OwnerId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
