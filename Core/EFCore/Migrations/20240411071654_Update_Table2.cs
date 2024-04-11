using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityTypeId",
                table: "Activities",
                newName: "ActivityType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "Activities",
                newName: "ActivityTypeId");
        }
    }
}
