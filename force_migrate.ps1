$connectionString = "Server=db38264.public.databaseasp.net;Database=db38264;User Id=db38264;Password=Ri9+4T?oWp6@;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"

Add-Type -AssemblyName "System.Data"
$conn = New-Object System.Data.SqlClient.SqlConnection
$conn.ConnectionString = $connectionString

try {
    $conn.Open()
    Write-Host "Veritabanına bağlanıldı!" -ForegroundColor Green
    
    # Önce mevcut tabloları temizle
    $dropTables = @"
IF OBJECT_ID('AttackTasks', 'U') IS NOT NULL DROP TABLE AttackTasks;
IF OBJECT_ID('BuildingPlans', 'U') IS NOT NULL DROP TABLE BuildingPlans;
IF OBJECT_ID('DailyTasks', 'U') IS NOT NULL DROP TABLE DailyTasks;
IF OBJECT_ID('Villages', 'U') IS NOT NULL DROP TABLE Villages;
IF OBJECT_ID('ScheduledOperations', 'U') IS NOT NULL DROP TABLE ScheduledOperations;
IF OBJECT_ID('WorldConfigs', 'U') IS NOT NULL DROP TABLE WorldConfigs;
IF OBJECT_ID('__EFMigrationsHistory', 'U') IS NOT NULL DROP TABLE __EFMigrationsHistory;
"@
    
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = $dropTables
    $cmd.ExecuteNonQuery() | Out-Null
    Write-Host "Eski tablolar temizlendi" -ForegroundColor Yellow
    
    # SQL dosyasını oku ve uygula
    $sqlScript = Get-Content -Path "migration_script.sql" -Raw
    $batches = $sqlScript -split "GO"
    
    $batchCount = 0
    foreach ($batch in $batches) {
        $batch = $batch.Trim()
        if ($batch.Length -gt 0) {
            $cmd = $conn.CreateCommand()
            $cmd.CommandText = $batch
            $cmd.CommandTimeout = 300
            
            try {
                $cmd.ExecuteNonQuery() | Out-Null
                $batchCount++
                Write-Host "." -NoNewline -ForegroundColor Green
            }
            catch {
                Write-Host "`nBatch hatası: $_" -ForegroundColor Red
            }
        }
    }
    
    Write-Host "`n$batchCount batch başarıyla çalıştırıldı!" -ForegroundColor Green
    Write-Host "Migration tamamlandı!" -ForegroundColor Green
}
catch {
    Write-Host "Bağlantı hatası: $_" -ForegroundColor Red
    Write-Host "`nVeritabanı mevcut değil. Lütfen databaseasp.net panelinden 'db38264' veritabanını oluştur." -ForegroundColor Yellow
}
finally {
    if ($conn.State -eq 'Open') {
        $conn.Close()
    }
}
