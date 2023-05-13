using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedpasswordtypev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "ApplicationUsers",
                type: "nvarchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "ApplicationUsers",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)");
        }
    }
}
