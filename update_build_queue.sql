-- Test için inşaat kuyruğu ekle
UPDATE Villages 
SET BuildQueueJson = '[
  {
    "BuildingType": "main",
    "CurrentLevel": 10,
    "TargetLevel": 11,
    "StartTime": "2026-01-14T20:50:00",
    "EndTime": "2026-01-14T22:50:00",
    "IsActive": true
  },
  {
    "BuildingType": "barracks",
    "CurrentLevel": 15,
    "TargetLevel": 16,
    "StartTime": "2026-01-14T22:50:00",
    "EndTime": "2026-01-15T00:20:00",
    "IsActive": false
  },
  {
    "BuildingType": "wall",
    "CurrentLevel": 18,
    "TargetLevel": 19,
    "StartTime": "2026-01-15T00:20:00",
    "EndTime": "2026-01-15T03:45:00",
    "IsActive": false
  }
]'
WHERE Id = 1;
