using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingGarage",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingGarage",
                table: "Villages");
        }
    }
}
