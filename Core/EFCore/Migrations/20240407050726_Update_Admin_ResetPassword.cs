using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_Admin_ResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordExpireTime",
                table: "Admins",
                type: "datetime2",
                nullable: true,
                comment: "重設密碼過期時間");

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "Admins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "重設密碼權杖");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordExpireTime",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "Admins");
        }
    }
}
