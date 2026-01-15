# Master veritabanına bağlan
$masterConnection = "Server=db38165.public.databaseasp.net;Database=master;User Id=db38165;Password=K+w23iT=_6xL;Encrypt=True;TrustServerCertificate=True"

Add-Type -AssemblyName "System.Data"
$conn = New-Object System.Data.SqlClient.SqlConnection
$conn.ConnectionString = $masterConnection

try {
    $conn.Open()
    Write-Host "Master veritabanına bağlanıldı..." -ForegroundColor Green
    
    # Veritabanını oluştur
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'db38165') CREATE DATABASE [db38165]"
    $cmd.ExecuteNonQuery() | Out-Null
    Write-Host "Veritabanı oluşturuldu" -ForegroundColor Green
    
    $conn.Close()
    
    # Şimdi migration'ı uygula
    $dbConnection = "Server=db38165.public.databaseasp.net;Database=db38165;User Id=db38165;Password=K+w23iT=_6xL;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
    $conn.ConnectionString = $dbConnection
    $conn.Open()
    
    Write-Host "db38165 veritabanına bağlanıldı..." -ForegroundColor Green
    
    # SQL dosyasını oku
    $sqlScript = Get-Content -Path "migration_script.sql" -Raw
    $batches = $sqlScript -split "GO"
    
    foreach ($batch in $batches) {
        $batch = $batch.Trim()
        if ($batch.Length -gt 0) {
            $cmd = $conn.CreateCommand()
            $cmd.CommandText = $batch
            $cmd.CommandTimeout = 300
            
            try {
                $cmd.ExecuteNonQuery() | Out-Null
                Write-Host "." -NoNewline -ForegroundColor Gray
            }
            catch {
                Write-Host "`nHata: $_" -ForegroundColor Red
            }
        }
    }
    
    Write-Host "`nMigration tamamlandı!" -ForegroundColor Green
}
catch {
    Write-Host "Hata: $_" -ForegroundColor Red
}
finally {
    if ($conn.State -eq 'Open') {
        $conn.Close()
    }
}
