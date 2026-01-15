using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecruitmentQueues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarracksQueueJson",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GarageQueueJson",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SnobQueueJson",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StableQueueJson",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarracksQueueJson",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "GarageQueueJson",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "SnobQueueJson",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "StableQueueJson",
                table: "Villages");
        }
    }
}
