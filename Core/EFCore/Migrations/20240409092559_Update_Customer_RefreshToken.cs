using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_Customer_RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "刷新令牌");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireAt",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                comment: "刷新令牌到期時間");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireAt",
                table: "Customers");
        }
    }
}
