-- Add BuildingGarage column to Villages table
ALTER TABLE Villages
ADD BuildingGarage INT NOT NULL DEFAULT 0;
