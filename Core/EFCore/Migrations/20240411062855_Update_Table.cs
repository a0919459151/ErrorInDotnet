using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "UpdaterId",
                table: "Customers",
                type: "int",
                nullable: true,
                comment: "UpdaterId",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                comment: "ID",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "CreateAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                comment: "DeleteAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "UpdateAt");

            migrationBuilder.AlterColumn<int>(
                name: "UpdaterId",
                table: "Admins",
                type: "int",
                nullable: true,
                comment: "UpdaterId",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                comment: "ID",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "CreateAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Admins",
                type: "datetime2",
                nullable: true,
                comment: "DeleteAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "UpdateAt");

            migrationBuilder.CreateTable(
                name: "ActivityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "類別名稱"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "CreateAt"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "UpdateAt"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "DeleteAt"),
                    UpdaterId = table.Column<int>(type: "int", nullable: true, comment: "UpdaterId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategories", x => x.Id);
                },
                comment: "活動類別");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "活動名稱"),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false, comment: "活動類型"),
                    ActivityCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "CreateAt"),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "UpdateAt"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "DeleteAt"),
                    UpdaterId = table.Column<int>(type: "int", nullable: true, comment: "UpdaterId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityCategories_ActivityCategoryId",
                        column: x => x.ActivityCategoryId,
                        principalTable: "ActivityCategories",
                        principalColumn: "Id");
                },
                comment: "活動");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityCategoryId",
                table: "Activities",
                column: "ActivityCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityCategories");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "UpdaterId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "UpdaterId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "UpdaterId",
                table: "Admins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "UpdaterId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "ID")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Admins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
