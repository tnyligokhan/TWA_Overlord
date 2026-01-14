using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TWA.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VillageId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEmergency = table.Column<bool>(type: "boolean", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    ExecutionLog = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mode = table.Column<int>(type: "integer", nullable: false),
                    TargetSpear = table.Column<int>(type: "integer", nullable: false),
                    TargetSword = table.Column<int>(type: "integer", nullable: false),
                    TargetAxe = table.Column<int>(type: "integer", nullable: false),
                    TargetArcher = table.Column<int>(type: "integer", nullable: false),
                    TargetSpy = table.Column<int>(type: "integer", nullable: false),
                    TargetLight = table.Column<int>(type: "integer", nullable: false),
                    TargetMarcher = table.Column<int>(type: "integer", nullable: false),
                    TargetHeavy = table.Column<int>(type: "integer", nullable: false),
                    TargetRam = table.Column<int>(type: "integer", nullable: false),
                    TargetCatapult = table.Column<int>(type: "integer", nullable: false),
                    TargetKnight = table.Column<int>(type: "integer", nullable: false),
                    TargetSnob = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CoordinateX = table.Column<int>(type: "integer", nullable: false),
                    CoordinateY = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    Loyalty = table.Column<int>(type: "integer", nullable: false),
                    WoodHourly = table.Column<int>(type: "integer", nullable: false),
                    StoneHourly = table.Column<int>(type: "integer", nullable: false),
                    IronHourly = table.Column<int>(type: "integer", nullable: false),
                    BuildingMain = table.Column<int>(type: "integer", nullable: false),
                    BuildingWood = table.Column<int>(type: "integer", nullable: false),
                    BuildingStone = table.Column<int>(type: "integer", nullable: false),
                    BuildingIron = table.Column<int>(type: "integer", nullable: false),
                    BuildingStorage = table.Column<int>(type: "integer", nullable: false),
                    BuildingFarm = table.Column<int>(type: "integer", nullable: false),
                    BuildingWall = table.Column<int>(type: "integer", nullable: false),
                    BuildingBarracks = table.Column<int>(type: "integer", nullable: false),
                    BuildingSmithy = table.Column<int>(type: "integer", nullable: false),
                    BuildingStable = table.Column<int>(type: "integer", nullable: false),
                    BuildingSnob = table.Column<int>(type: "integer", nullable: false),
                    AiAction = table.Column<string>(type: "text", nullable: false),
                    AiTarget = table.Column<string>(type: "text", nullable: false),
                    WallLevel = table.Column<int>(type: "integer", nullable: false),
                    BarracksLevel = table.Column<int>(type: "integer", nullable: false),
                    SmithyLevel = table.Column<int>(type: "integer", nullable: false),
                    StableLevel = table.Column<int>(type: "integer", nullable: false),
                    AcademyLevel = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Wood = table.Column<int>(type: "integer", nullable: false),
                    Stone = table.Column<int>(type: "integer", nullable: false),
                    Iron = table.Column<int>(type: "integer", nullable: false),
                    StorageCapacity = table.Column<int>(type: "integer", nullable: false),
                    PopulationCurrent = table.Column<int>(type: "integer", nullable: false),
                    PopulationMax = table.Column<int>(type: "integer", nullable: false),
                    Own_Spear = table.Column<int>(type: "integer", nullable: false),
                    Own_Sword = table.Column<int>(type: "integer", nullable: false),
                    Own_Axe = table.Column<int>(type: "integer", nullable: false),
                    Own_Spy = table.Column<int>(type: "integer", nullable: false),
                    Own_Light = table.Column<int>(type: "integer", nullable: false),
                    Own_Heavy = table.Column<int>(type: "integer", nullable: false),
                    Own_Ram = table.Column<int>(type: "integer", nullable: false),
                    Own_Catapult = table.Column<int>(type: "integer", nullable: false),
                    Own_Knight = table.Column<int>(type: "integer", nullable: false),
                    Own_Snob = table.Column<int>(type: "integer", nullable: false),
                    Own_Militia = table.Column<int>(type: "integer", nullable: false),
                    Total_Spear = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Sword = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Axe = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Spy = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Light = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Heavy = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Ram = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Catapult = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Knight = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Snob = table.Column<int>(type: "integer", nullable: false),
                    TotalTroops_Militia = table.Column<int>(type: "integer", nullable: false),
                    AvailableMerchants = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorldId = table.Column<int>(type: "integer", nullable: false),
                    GameSpeed = table.Column<double>(type: "double precision", nullable: false),
                    UnitSpeed = table.Column<double>(type: "double precision", nullable: false),
                    ArchersActive = table.Column<bool>(type: "boolean", nullable: false),
                    PaladinActive = table.Column<bool>(type: "boolean", nullable: false),
                    FakeLimitPercent = table.Column<int>(type: "integer", nullable: false),
                    MillisecondsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LagRandomizationMs = table.Column<int>(type: "integer", nullable: false),
                    NightBonusActive = table.Column<bool>(type: "boolean", nullable: false),
                    NightStart = table.Column<TimeSpan>(type: "interval", nullable: false),
                    NightEnd = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttackTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceVillageId = table.Column<int>(type: "integer", nullable: false),
                    TargetX = table.Column<int>(type: "integer", nullable: false),
                    TargetY = table.Column<int>(type: "integer", nullable: false),
                    TargetPlayerName = table.Column<string>(type: "text", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Troops_Spear = table.Column<int>(type: "integer", nullable: false),
                    Troops_Sword = table.Column<int>(type: "integer", nullable: false),
                    Troops_Axe = table.Column<int>(type: "integer", nullable: false),
                    Troops_Spy = table.Column<int>(type: "integer", nullable: false),
                    Troops_Light = table.Column<int>(type: "integer", nullable: false),
                    Troops_Heavy = table.Column<int>(type: "integer", nullable: false),
                    Troops_Ram = table.Column<int>(type: "integer", nullable: false),
                    Troops_Catapult = table.Column<int>(type: "integer", nullable: false),
                    Troops_Knight = table.Column<int>(type: "integer", nullable: false),
                    Troops_Snob = table.Column<int>(type: "integer", nullable: false),
                    Troops_Militia = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    GroqNotes = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VillageId = table.Column<int>(type: "integer", nullable: false),
                    BuildingName = table.Column<string>(type: "text", nullable: false),
                    TargetLevel = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VillageId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ActionTarget = table.Column<string>(type: "text", nullable: false),
                    TaskName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Villages_VillageId",
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
                name: "IX_DailyTasks_VillageId",
                table: "DailyTasks",
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
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "ScheduledOperations");

            migrationBuilder.DropTable(
                name: "WorldConfigs");

            migrationBuilder.DropTable(
                name: "Villages");
        }
    }
}
