IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [ScheduledOperations] (
    [Id] int NOT NULL IDENTITY,
    [VillageId] int NOT NULL,
    [Type] int NOT NULL,
    [ScheduledTime] datetime2 NOT NULL,
    [IsEmergency] bit NOT NULL,
    [Payload] nvarchar(max) NOT NULL,
    [IsCompleted] bit NOT NULL,
    [ExecutionLog] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_ScheduledOperations] PRIMARY KEY ([Id])
);

CREATE TABLE [Villages] (
    [Id] int NOT NULL IDENTITY,
    [Mode] int NOT NULL,
    [TargetSpear] int NOT NULL,
    [TargetSword] int NOT NULL,
    [TargetAxe] int NOT NULL,
    [TargetArcher] int NOT NULL,
    [TargetSpy] int NOT NULL,
    [TargetLight] int NOT NULL,
    [TargetMarcher] int NOT NULL,
    [TargetHeavy] int NOT NULL,
    [TargetRam] int NOT NULL,
    [TargetCatapult] int NOT NULL,
    [TargetKnight] int NOT NULL,
    [TargetSnob] int NOT NULL,
    [GameId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [CoordinateX] int NOT NULL,
    [CoordinateY] int NOT NULL,
    [Points] int NOT NULL,
    [Loyalty] int NOT NULL,
    [WoodHourly] int NOT NULL,
    [StoneHourly] int NOT NULL,
    [IronHourly] int NOT NULL,
    [BuildingMain] int NOT NULL,
    [BuildingWood] int NOT NULL,
    [BuildingStone] int NOT NULL,
    [BuildingIron] int NOT NULL,
    [BuildingStorage] int NOT NULL,
    [BuildingFarm] int NOT NULL,
    [BuildingWall] int NOT NULL,
    [BuildingBarracks] int NOT NULL,
    [BuildingSmithy] int NOT NULL,
    [BuildingStable] int NOT NULL,
    [BuildingGarage] int NOT NULL,
    [BuildingSnob] int NOT NULL,
    [BuildingStatue] int NOT NULL,
    [BuildingMarket] int NOT NULL,
    [TotalMerchants] int NOT NULL,
    [KnightName] nvarchar(max) NOT NULL,
    [IsKnightLocal] bit NOT NULL,
    [ResearchSpear] int NOT NULL,
    [ResearchSword] int NOT NULL,
    [ResearchAxe] int NOT NULL,
    [ResearchSpy] int NOT NULL,
    [ResearchLight] int NOT NULL,
    [ResearchHeavy] int NOT NULL,
    [ResearchRam] int NOT NULL,
    [ResearchCatapult] int NOT NULL,
    [BuildQueueJson] nvarchar(max) NOT NULL,
    [BarracksQueueJson] nvarchar(max) NOT NULL,
    [StableQueueJson] nvarchar(max) NOT NULL,
    [GarageQueueJson] nvarchar(max) NOT NULL,
    [SnobQueueJson] nvarchar(max) NOT NULL,
    [FlagsJson] nvarchar(max) NOT NULL,
    [AiAction] nvarchar(max) NOT NULL,
    [AiTarget] nvarchar(max) NOT NULL,
    [WallLevel] int NOT NULL,
    [BarracksLevel] int NOT NULL,
    [SmithyLevel] int NOT NULL,
    [StableLevel] int NOT NULL,
    [AcademyLevel] int NOT NULL,
    [Type] int NOT NULL,
    [Wood] int NOT NULL,
    [Stone] int NOT NULL,
    [Iron] int NOT NULL,
    [StorageCapacity] int NOT NULL,
    [PopulationCurrent] int NOT NULL,
    [PopulationMax] int NOT NULL,
    [Own_Spear] int NOT NULL DEFAULT 0,
    [Own_Sword] int NOT NULL DEFAULT 0,
    [Own_Axe] int NOT NULL DEFAULT 0,
    [Own_Spy] int NOT NULL DEFAULT 0,
    [Own_Light] int NOT NULL DEFAULT 0,
    [Own_Heavy] int NOT NULL DEFAULT 0,
    [Own_Ram] int NOT NULL DEFAULT 0,
    [Own_Catapult] int NOT NULL DEFAULT 0,
    [Own_Knight] int NOT NULL DEFAULT 0,
    [Own_Snob] int NOT NULL DEFAULT 0,
    [Own_Militia] int NOT NULL DEFAULT 0,
    [Total_Spear] int NOT NULL DEFAULT 0,
    [Total_Sword] int NOT NULL DEFAULT 0,
    [Total_Axe] int NOT NULL DEFAULT 0,
    [Total_Spy] int NOT NULL DEFAULT 0,
    [Total_Light] int NOT NULL DEFAULT 0,
    [Total_Heavy] int NOT NULL DEFAULT 0,
    [Total_Ram] int NOT NULL DEFAULT 0,
    [Total_Catapult] int NOT NULL DEFAULT 0,
    [Total_Knight] int NOT NULL DEFAULT 0,
    [Total_Snob] int NOT NULL DEFAULT 0,
    [Total_Militia] int NOT NULL DEFAULT 0,
    [AvailableMerchants] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Villages] PRIMARY KEY ([Id])
);

CREATE TABLE [WorldConfigs] (
    [Id] int NOT NULL IDENTITY,
    [WorldId] int NOT NULL,
    [GameSpeed] float NOT NULL,
    [UnitSpeed] float NOT NULL,
    [ArchersActive] bit NOT NULL,
    [PaladinActive] bit NOT NULL,
    [FakeLimitPercent] int NOT NULL,
    [MillisecondsActive] bit NOT NULL,
    [LagRandomizationMs] int NOT NULL,
    [NightBonusActive] bit NOT NULL,
    [NightStart] time NOT NULL,
    [NightEnd] time NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_WorldConfigs] PRIMARY KEY ([Id])
);

CREATE TABLE [AttackTasks] (
    [Id] int NOT NULL IDENTITY,
    [SourceVillageId] int NOT NULL,
    [TargetX] int NOT NULL,
    [TargetY] int NOT NULL,
    [TargetPlayerName] nvarchar(max) NOT NULL,
    [LaunchTime] datetime2 NOT NULL,
    [ArrivalTime] datetime2 NULL,
    [Troops_Spear] int NOT NULL,
    [Troops_Sword] int NOT NULL,
    [Troops_Axe] int NOT NULL,
    [Troops_Spy] int NOT NULL,
    [Troops_Light] int NOT NULL,
    [Troops_Heavy] int NOT NULL,
    [Troops_Ram] int NOT NULL,
    [Troops_Catapult] int NOT NULL,
    [Troops_Knight] int NOT NULL,
    [Troops_Snob] int NOT NULL,
    [Troops_Militia] int NOT NULL,
    [Type] int NOT NULL,
    [Status] int NOT NULL,
    [GroqNotes] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_AttackTasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AttackTasks_Villages_SourceVillageId] FOREIGN KEY ([SourceVillageId]) REFERENCES [Villages] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [BuildingPlans] (
    [Id] int NOT NULL IDENTITY,
    [VillageId] int NOT NULL,
    [BuildingName] nvarchar(max) NOT NULL,
    [TargetLevel] int NOT NULL,
    [Priority] int NOT NULL,
    [IsActive] bit NOT NULL,
    [StartTime] datetime2 NULL,
    [EndTime] datetime2 NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_BuildingPlans] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BuildingPlans_Villages_VillageId] FOREIGN KEY ([VillageId]) REFERENCES [Villages] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [DailyTasks] (
    [Id] int NOT NULL IDENTITY,
    [VillageId] int NOT NULL,
    [Type] int NOT NULL,
    [ActionTarget] nvarchar(max) NOT NULL,
    [TaskName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [IsCompleted] bit NOT NULL,
    [ScheduledTime] datetime2 NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_DailyTasks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DailyTasks_Villages_VillageId] FOREIGN KEY ([VillageId]) REFERENCES [Villages] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_AttackTasks_SourceVillageId] ON [AttackTasks] ([SourceVillageId]);

CREATE INDEX [IX_BuildingPlans_VillageId] ON [BuildingPlans] ([VillageId]);

CREATE INDEX [IX_DailyTasks_VillageId] ON [DailyTasks] ([VillageId]);

CREATE UNIQUE INDEX [IX_Villages_CoordinateX_CoordinateY] ON [Villages] ([CoordinateX], [CoordinateY]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260115212905_InitialCreate', N'9.0.0');

COMMIT;
GO

