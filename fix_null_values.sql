-- Fix NULL values in Villages table
-- This script ensures all required fields have proper default values

-- Update KnightName if NULL
UPDATE Villages
SET KnightName = ''
WHERE KnightName IS NULL;

-- Update JSON fields if NULL
UPDATE Villages
SET BuildQueueJson = '[]'
WHERE BuildQueueJson IS NULL;

UPDATE Villages
SET BarracksQueueJson = '[]'
WHERE BarracksQueueJson IS NULL;

UPDATE Villages
SET StableQueueJson = '[]'
WHERE StableQueueJson IS NULL;

UPDATE Villages
SET GarageQueueJson = '[]'
WHERE GarageQueueJson IS NULL;

UPDATE Villages
SET SnobQueueJson = '[]'
WHERE SnobQueueJson IS NULL;

UPDATE Villages
SET FlagsJson = '{}'
WHERE FlagsJson IS NULL;

-- Update AI fields if NULL
UPDATE Villages
SET AiAction = 'BUILD'
WHERE AiAction IS NULL;

UPDATE Villages
SET AiTarget = ''
WHERE AiTarget IS NULL;

-- Update Name if NULL
UPDATE Villages
SET Name = 'Unknown Village'
WHERE Name IS NULL OR Name = '';

-- Check for any remaining NULL values in required fields
SELECT 
    Id,
    Name,
    KnightName,
    BuildQueueJson,
    BarracksQueueJson,
    StableQueueJson,
    GarageQueueJson,
    SnobQueueJson,
    FlagsJson,
    AiAction,
    AiTarget
FROM Villages
WHERE 
    KnightName IS NULL OR
    BuildQueueJson IS NULL OR
    BarracksQueueJson IS NULL OR
    StableQueueJson IS NULL OR
    GarageQueueJson IS NULL OR
    SnobQueueJson IS NULL OR
    FlagsJson IS NULL OR
    AiAction IS NULL OR
    AiTarget IS NULL OR
    Name IS NULL;
