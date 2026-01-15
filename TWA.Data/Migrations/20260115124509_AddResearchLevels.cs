using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddResearchLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResearchAxe",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchCatapult",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchHeavy",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchLight",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchRam",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchSpear",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchSpy",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResearchSword",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResearchAxe",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchCatapult",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchHeavy",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchLight",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchRam",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchSpear",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchSpy",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ResearchSword",
                table: "Villages");
        }
    }
}
