using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaForWarfare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetArcher",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetAxe",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetCatapult",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetHeavy",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetKnight",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetLight",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetMarcher",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetRam",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetSnob",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetSpear",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetSpy",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetSword",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DailyTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActionTarget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTask_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyTask_VillageId",
                table: "DailyTask",
                column: "VillageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyTask");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetArcher",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetAxe",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetCatapult",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetHeavy",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetKnight",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetLight",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetMarcher",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetRam",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetSnob",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetSpear",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetSpy",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "TargetSword",
                table: "Villages");
        }
    }
}
