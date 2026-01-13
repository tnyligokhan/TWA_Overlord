using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduledAndDailyTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyTask_Villages_VillageId",
                table: "DailyTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyTask",
                table: "DailyTask");

            migrationBuilder.RenameTable(
                name: "DailyTask",
                newName: "DailyTasks");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTask_VillageId",
                table: "DailyTasks",
                newName: "IX_DailyTasks_VillageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyTasks",
                table: "DailyTasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ScheduledOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ExecutionLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledOperations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTasks_Villages_VillageId",
                table: "DailyTasks",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Villages_VillageId",
                table: "DailyTasks");

            migrationBuilder.DropTable(
                name: "ScheduledOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyTasks",
                table: "DailyTasks");

            migrationBuilder.RenameTable(
                name: "DailyTasks",
                newName: "DailyTask");

            migrationBuilder.RenameIndex(
                name: "IX_DailyTasks_VillageId",
                table: "DailyTask",
                newName: "IX_DailyTask_VillageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyTask",
                table: "DailyTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTask_Villages_VillageId",
                table: "DailyTask",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
