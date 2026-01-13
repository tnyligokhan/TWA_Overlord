using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinateX = table.Column<int>(type: "int", nullable: false),
                    CoordinateY = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Loyalty = table.Column<int>(type: "int", nullable: false),
                    WoodHourly = table.Column<int>(type: "int", nullable: false),
                    StoneHourly = table.Column<int>(type: "int", nullable: false),
                    IronHourly = table.Column<int>(type: "int", nullable: false),
                    BuildingMain = table.Column<int>(type: "int", nullable: false),
                    BuildingWood = table.Column<int>(type: "int", nullable: false),
                    BuildingStone = table.Column<int>(type: "int", nullable: false),
                    BuildingIron = table.Column<int>(type: "int", nullable: false),
                    BuildingStorage = table.Column<int>(type: "int", nullable: false),
                    BuildingFarm = table.Column<int>(type: "int", nullable: false),
                    BuildingWall = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Wood = table.Column<int>(type: "int", nullable: false),
                    Stone = table.Column<int>(type: "int", nullable: false),
                    Iron = table.Column<int>(type: "int", nullable: false),
                    StorageCapacity = table.Column<int>(type: "int", nullable: false),
                    PopulationCurrent = table.Column<int>(type: "int", nullable: false),
                    PopulationMax = table.Column<int>(type: "int", nullable: false),
                    Own_Spear = table.Column<int>(type: "int", nullable: false),
                    Own_Sword = table.Column<int>(type: "int", nullable: false),
                    Own_Axe = table.Column<int>(type: "int", nullable: false),
                    Own_Spy = table.Column<int>(type: "int", nullable: false),
                    Own_Light = table.Column<int>(type: "int", nullable: false),
                    Own_Heavy = table.Column<int>(type: "int", nullable: false),
                    Own_Ram = table.Column<int>(type: "int", nullable: false),
                    Own_Catapult = table.Column<int>(type: "int", nullable: false),
                    Own_Knight = table.Column<int>(type: "int", nullable: false),
                    Own_Snob = table.Column<int>(type: "int", nullable: false),
                    Own_Militia = table.Column<int>(type: "int", nullable: false),
                    Total_Spear = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Sword = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Axe = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Spy = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Light = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Heavy = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Ram = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Catapult = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Knight = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Snob = table.Column<int>(type: "int", nullable: false),
                    TotalTroops_Militia = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorldId = table.Column<int>(type: "int", nullable: false),
                    GameSpeed = table.Column<double>(type: "float", nullable: false),
                    UnitSpeed = table.Column<double>(type: "float", nullable: false),
                    ArchersActive = table.Column<bool>(type: "bit", nullable: false),
                    PaladinActive = table.Column<bool>(type: "bit", nullable: false),
                    FakeLimitPercent = table.Column<int>(type: "int", nullable: false),
                    MillisecondsActive = table.Column<bool>(type: "bit", nullable: false),
                    LagRandomizationMs = table.Column<int>(type: "int", nullable: false),
                    NightBonusActive = table.Column<bool>(type: "bit", nullable: false),
                    NightStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    NightEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttackTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceVillageId = table.Column<int>(type: "int", nullable: false),
                    TargetX = table.Column<int>(type: "int", nullable: false),
                    TargetY = table.Column<int>(type: "int", nullable: false),
                    TargetPlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Troops_Spear = table.Column<int>(type: "int", nullable: false),
                    Troops_Sword = table.Column<int>(type: "int", nullable: false),
                    Troops_Axe = table.Column<int>(type: "int", nullable: false),
                    Troops_Spy = table.Column<int>(type: "int", nullable: false),
                    Troops_Light = table.Column<int>(type: "int", nullable: false),
                    Troops_Heavy = table.Column<int>(type: "int", nullable: false),
                    Troops_Ram = table.Column<int>(type: "int", nullable: false),
                    Troops_Catapult = table.Column<int>(type: "int", nullable: false),
                    Troops_Knight = table.Column<int>(type: "int", nullable: false),
                    Troops_Snob = table.Column<int>(type: "int", nullable: false),
                    Troops_Militia = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroqNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackTasks_Villages_SourceVillageId",
                        column: x => x.SourceVillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetLevel = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingPlans_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttackTasks_SourceVillageId",
                table: "AttackTasks",
                column: "SourceVillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingPlans_VillageId",
                table: "BuildingPlans",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_CoordinateX_CoordinateY",
                table: "Villages",
                columns: new[] { "CoordinateX", "CoordinateY" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackTasks");

            migrationBuilder.DropTable(
                name: "BuildingPlans");

            migrationBuilder.DropTable(
                name: "WorldConfigs");

            migrationBuilder.DropTable(
                name: "Villages");
        }
    }
}
