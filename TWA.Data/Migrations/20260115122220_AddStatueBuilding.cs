using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatueBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingStatue",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingStatue",
                table: "Villages");
        }
    }
}
