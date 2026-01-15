using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildQueueJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildQueueJson",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildQueueJson",
                table: "Villages");
        }
    }
}
