# TWA Overlord - Panel API ve Sınıf Dokümantasyonu

## 📋 İçindekiler
1. [Controller Endpoint'leri](#controller-endpointleri)
2. [Entity Sınıfları](#entity-sınıfları)
3. [ViewModel Sınıfları](#viewmodel-sınıfları)
4. [SignalR Hub](#signalr-hub)
5. [Servis Interface'leri](#servis-interfaceleri)

---

## 🎯 Controller Endpoint'leri

### 1. Dashboard Controller
**Base Route:** `/Dashboard`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Dashboard/Index` | Ana dashboard sayfası | `DashboardViewModel`, `Village`, `AttackTask` |
| POST | `/Dashboard/ConnectGame` | Oyuna bağlan ve veri senkronize et | `IGameBrowserService`, `IVillageService` |

**Kullanılan Entity'ler:**
- `Village` - Köy bilgileri
- `AttackTask` - Saldırı görevleri
- `LogisticsRoute` - Lojistik rotaları

**Kullanılan Servisler:**
- `IVillageService` - Köy işlemleri
- `IUnitOfWork` - Veritabanı işlemleri
- `IGroqAiService` - AI servisi
- `IGameBrowserService` - Tarayıcı otomasyonu

---

### 2. Attack Controller
**Base Route:** `/Attack`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Attack/Index` | Saldırı yönetim sayfası | `WarRoomViewModel`, `Village`, `AttackTask` |
| POST | `/Attack/ScheduleAttack` | Yeni saldırı planla | `AttackTask`, `WarRoomViewModel` |
| GET | `/Attack/Cancel/{id}` | Saldırıyı iptal et | `AttackTask` |

**Kullanılan Entity'ler:**
- `Village` - Kaynak köy
- `AttackTask` - Saldırı görevi
- `AttackType` - Saldırı tipi enum (Fake, Farm, Real_Nuke, Real_Noble, Snipe, Support)
- `AttackStatus` - Saldırı durumu enum (Pending, Scheduled, Sent, Cancelled, Failed)
- `TroopSet` - Asker bilgileri

**Kullanılan Servisler:**
- `IUnitOfWork` - Veritabanı işlemleri
- `IWarfareService` - Savaş işlemleri

---

### 3. Economy Controller
**Base Route:** `/Economy`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Economy/Index` | Ekonomi yönetim sayfası | `EconomyViewModel`, `Village`, `VillageEconomyState` |
| POST | `/Economy/DistributeResources` | Kaynakları otomatik dağıt | `IEconomyService` |
| POST | `/Economy/MintCoins` | Altın para bas | `IEconomyService` |

**Kullanılan Entity'ler:**
- `Village` - Köy bilgileri
- `VillageEconomyState` - Köy ekonomi durumu

**Kullanılan Servisler:**
- `IUnitOfWork` - Veritabanı işlemleri
- `IEconomyService` - Ekonomi işlemleri

---

### 4. Emergency Controller
**Base Route:** `/Emergency`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Emergency/Index` | Acil durum kontrol paneli | - |
| POST | `/Emergency/ToggleKillSwitch` | Kill switch aç/kapat | `IEmergencyService` |
| POST | `/Emergency/PanicDefense` | Toplu savunma modu | `IEmergencyService` |

**Kullanılan Servisler:**
- `IEmergencyService` - Acil durum servisi

---

### 5. Garrison Controller
**Base Route:** `/Garrison`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Garrison/Index` | Garnizon yönetim sayfası | `Village`, `TroopSet` |
| GET | `/Garrison/GetTroops/{villageId}` | Köy askerlerini getir (JSON) | `Village`, `TroopSet` |

**Kullanılan Entity'ler:**
- `Village` - Köy bilgileri
- `TroopSet` - Asker bilgileri (Spear, Sword, Axe, Light, Heavy, Ram, Catapult, Snob)

**Kullanılan Servisler:**
- `IUnitOfWork` - Veritabanı işlemleri

---

### 6. Infrastructure Controller
**Base Route:** `/Infrastructure`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Infrastructure/Index` | İnşaat yönetim sayfası | `InfrastructureViewModel`, `ConstructionTask` |

**Kullanılan Entity'ler:**
- `ConstructionTask` - İnşaat görevi
- `InfrastructureViewModel` - İnşaat view modeli

---

### 7. Map Controller
**Base Route:** `/Map`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Map/Index` | Harita radar sayfası | `MapRadarViewModel`, `Village` |
| POST | `/Map/Scan` | Harita taraması yap | `MapRadarViewModel` |

**Kullanılan Entity'ler:**
- `Village` - Köy bilgileri
- `VillageType` - Köy tipi enum (Own, Barbarian, Enemy, Ally)
- `MapRadarViewModel` - Harita filtreleri

**Kullanılan Servisler:**
- `IMapScannerService` - Harita tarama servisi
- `IUnitOfWork` - Veritabanı işlemleri

---

### 8. Village Controller
**Base Route:** `/Village`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Village/Index` | Köy listesi sayfası | `Village` |
| GET | `/Village/Details/{id}` | Köy detay sayfası | `Village`, `TroopSet`, `BuildingPlan` |

**Kullanılan Entity'ler:**
- `Village` - Köy bilgileri
- `TroopSet` - Asker bilgileri
- `BuildingPlan` - İnşaat planları

**Kullanılan Servisler:**
- `IUnitOfWork` - Veritabanı işlemleri

---

### 9. Warfare Controller
**Base Route:** `/Warfare`

| HTTP Method | Endpoint | Açıklama | Kullanılan Sınıflar |
|------------|----------|----------|-------------------|
| GET | `/Warfare/Index` | Savaş stratejileri sayfası | `WarfareViewModel`, `AttackTask` |
| POST | `/Warfare/LaunchGhostTrain` | Ghost train saldırısı başlat | `DeceptionService` |
| POST | `/Warfare/CalculateSnipe` | Snipe hesapla | `OpCoordinatorService` |

**Kullanılan Entity'ler:**
- `AttackTask` - Saldırı görevi
- `WarfareViewModel` - Savaş view modeli

**Kullanılan Servisler:**
- `DeceptionService` - Aldatma taktikleri servisi
- `OpCoordinatorService` - Operasyon koordinasyon servisi
- `IUnitOfWork` - Veritabanı işlemleri

---

## 📦 Entity Sınıfları

### Village (Köy)
**Namespace:** `TWA.Core.Entities`

**Özellikler:**
```csharp
// Temel Bilgiler
int Id
int GameId                    // Oyun içi ID
string Name                   // Köy adı
int CoordinateX               // X koordinatı
int CoordinateY               // Y koordinatı
string Coordinates            // "X|Y" formatında
int Points                    // Puan
int Loyalty                   // Sadakat (0-100)
VillageType Type              // Own, Barbarian, Enemy, Ally
VillageMode Mode              // Balanced, Offensive, Defensive, Farm, Spy

// Ekonomi
int Wood                      // Odun
int Stone                     // Taş (Clay)
int Iron                      // Demir
int StorageCapacity           // Depo kapasitesi
int WoodHourly                // Saatlik odun üretimi
int StoneHourly               // Saatlik taş üretimi
int IronHourly                // Saatlik demir üretimi

// Nüfus
int PopulationCurrent         // Mevcut nüfus
int PopulationMax             // Maksimum nüfus

// Binalar
int BuildingMain              // Genel Merkez
int BuildingWood              // Oduncu
int BuildingStone             // Kil Ocağı
int BuildingIron              // Demir Madeni
int BuildingStorage           // Depo
int BuildingFarm              // Çiftlik
int BuildingWall              // Sur
int BuildingBarracks          // Kışla
int BuildingSmithy            // Demirci
int BuildingStable            // Ahır
int BuildingSnob              // Akademi

// Askerler
TroopSet OwnedTroops          // Köydeki askerler
TroopSet TotalTroops          // Toplam askerler (dışarıdakiler dahil)

// Hedef Asker Sayıları
int TargetSpear, TargetSword, TargetAxe, TargetArcher, TargetSpy
int TargetLight, TargetMarcher, TargetHeavy, TargetRam
int TargetCatapult, TargetKnight, TargetSnob

// Lojistik
int AvailableMerchants        // Müsait tüccar sayısı

// AI
string AiAction               // AI aksiyonu
string AiTarget               // AI hedefi

// İlişkiler
List<BuildingPlan> BuildQueue
List<AttackTask> Attacks
ICollection<DailyTask> DailyTasks
```

**Metodlar:**
```csharp
bool IsStorageNearFull()                           // Depo %90 dolu mu?
bool NeedsResources()                              // Kaynak ihtiyacı var mı?
bool HasExcessResources()                          // Fazla kaynak var mı?
string AvailableTroopsSummary()                    // Asker özeti
double DistanceTo(int targetX, int targetY)        // Hedefe mesafe
```

---

### AttackTask (Saldırı Görevi)
**Namespace:** `TWA.Core.Entities`

**Özellikler:**
```csharp
int Id
int SourceVillageId           // Kaynak köy ID
Village SourceVillage         // Kaynak köy
int TargetX                   // Hedef X koordinatı
int TargetY                   // Hedef Y koordinatı
string TargetPlayerName       // Hedef oyuncu adı
DateTime LaunchTime           // Çıkış zamanı
DateTime? ArrivalTime         // Varış zamanı (Snipe için)
TroopSet Troops               // Gönderilecek askerler
AttackType Type               // Saldırı tipi
AttackStatus Status           // Saldırı durumu
string GroqNotes              // AI notları
string SourceVillageName      // Kaynak köy adı (computed)
string TargetCoordinates      // "X|Y" formatında (computed)
```

**Enum'lar:**
```csharp
AttackType: Fake, Farm, Real_Nuke, Real_Noble, Snipe, Support
AttackStatus: Pending, Scheduled, Sent, Cancelled, Failed
```

---

### TroopSet (Asker Seti)
**Namespace:** `TWA.Core.Entities`

**Özellikler:**
```csharp
int Spear                     // Mızrakçı
int Sword                     // Kılıççı
int Axe                       // Baltacı
int Spy                       // Casus
int Light                     // Hafif Atlı
int Heavy                     // Ağır Atlı
int Ram                       // Şahmerdan
int Catapult                  // Mancınık
int Knight                    // Şövalye
int Snob                      // Misyoner
int Militia                   // Milis
```

**Metodlar:**
```csharp
int TotalPopulation()         // Toplam popülasyon
int Total()                   // Toplam asker sayısı
```

---

### BuildingPlan (İnşaat Planı)
**Namespace:** `TWA.Core.Entities`

**Özellikler:**
```csharp
int Id
int VillageId                 // Köy ID
Village Village               // Köy
string BuildingName           // Bina adı (main, barracks, wall, vb.)
int TargetLevel               // Hedef seviye
int Priority                  // Öncelik (1-5)
bool IsActive                 // Aktif mi?
DateTime? StartTime           // Başlangıç zamanı
DateTime? EndTime             // Bitiş zamanı
```

---

### TransportCommand (Taşıma Komutu)
**Namespace:** `TWA.Core.Entities`

**Özellikler:**
```csharp
int SourceId                  // Kaynak köy ID
int TargetX                   // Hedef X koordinatı
int TargetY                   // Hedef Y koordinatı
int Wood                      // Odun miktarı
int Stone                     // Taş miktarı
int Iron                      // Demir miktarı
```

---

## 📊 ViewModel Sınıfları

### DashboardViewModel
**Namespace:** `TWA.Web.Controllers`

**Özellikler:**
```csharp
int TotalVillages                              // Toplam köy sayısı
int TotalPoints                                // Toplam puan
int ActiveAttacks                              // Aktif saldırı sayısı
int LowStorageVillages                         // Düşük kaynaklı köy sayısı
int FullStorageVillages                        // Dolu depolu köy sayısı
IEnumerable<AttackTask> ActiveAttackList       // Aktif saldırı listesi
List<string> RecentLogs                        // Son sistem logları
int TotalGoldCoins                             // Toplam altın para
List<LogisticsRoute> ActiveLogistics           // Aktif lojistik rotaları
```

### LogisticsRoute
**Özellikler:**
```csharp
string SourceVillageName      // Kaynak köy adı
string TargetVillageName      // Hedef köy adı
string ArrivalTime            // Varış zamanı
```

---

### WarRoomViewModel
**Namespace:** `TWA.Web.Models`

**Özellikler:**
```csharp
IEnumerable<Village> MyVillages                // Köylerim
IEnumerable<AttackTask> Attacks                // Saldırılar
AttackTask NewTask                             // Yeni saldırı formu
int CurrentVillageId                           // Seçili köy ID
```

---

### EconomyViewModel
**Namespace:** `TWA.Web.Models`

**Özellikler:**
```csharp
long TotalWood                                 // Toplam odun
long TotalClay                                 // Toplam kil
long TotalIron                                 // Toplam demir
int TotalGoldCoins                             // Toplam altın para
int TotalProductionPerHour                     // Saatlik üretim
int TotalMerchantsAvailable                    // Müsait tüccar sayısı
List<VillageEconomyState> VillageResources     // Köy ekonomi durumları
```

### VillageEconomyState
**Özellikler:**
```csharp
int VillageId                 // Köy ID
string VillageName            // Köy adı
string Coordinates            // Koordinatlar
int Wood                      // Odun
int Clay                      // Kil
int Iron                      // Demir
int StorageCapacity           // Depo kapasitesi
bool IsStorageFull            // Depo dolu mu? (computed)
string BestRoiBuilding        // En iyi ROI binası
int ActiveMerchants           // Aktif tüccar
int TotalMerchants            // Toplam tüccar
```

---

### InfrastructureViewModel
**Namespace:** `TWA.Web.Models`

**Özellikler:**
```csharp
List<ConstructionTask> ActiveBuilds            // Aktif inşaatlar
List<ConstructionTask> BuildQueue              // İnşaat kuyruğu
```

### ConstructionTask
**Özellikler:**
```csharp
string Id                     // Görev ID
string VillageName            // Köy adı
string BuildingName           // Bina adı
string BuildingIcon           // Bina ikonu (FontAwesome)
int CurrentLevel              // Mevcut seviye
int TargetLevel               // Hedef seviye
DateTime StartTime            // Başlangıç zamanı
DateTime EndTime              // Bitiş zamanı
TimeSpan Duration             // Süre (computed)
TimeSpan Remaining            // Kalan süre (computed)
int Progress                  // İlerleme yüzdesi (0-100, computed)
bool IsActive                 // Aktif mi?
```

---

### MapRadarViewModel
**Namespace:** `TWA.Web.Models`

**Özellikler:**
```csharp
int CenterX                   // Merkez X koordinatı (default: 500)
int CenterY                   // Merkez Y koordinatı (default: 500)
int Radius                    // Tarama yarıçapı (default: 15)
int MinPoints                 // Minimum puan (default: 0)
int MaxPoints                 // Maksimum puan (default: 3000)
IEnumerable<Village> Targets  // Hedef köyler
int BarbarianCount            // Barbar köy sayısı (computed)
int PlayerCount               // Oyuncu köy sayısı (computed)
```

---

### WarfareViewModel
**Namespace:** `TWA.Web.Models`

**Özellikler:**
```csharp
List<AttackTask> ActiveAttacks                 // Aktif saldırılar
int TodayAttackCount                           // Bugünkü saldırı sayısı
double SuccessRate                             // Başarı oranı
long TotalLoot                                 // Toplam yağma
```

---

## 🔌 SignalR Hub

### GameDataHub
**Endpoint:** `/gameDataHub`
**Namespace:** `TWA.Web.Hubs`

**Kullanım:**
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameDataHub")
    .build();

// Canlı veri dinleme
connection.on("ReceiveVillageUpdate", (data) => {
    // Köy verisi güncellendi
});

connection.on("ReceiveAttackUpdate", (data) => {
    // Saldırı verisi güncellendi
});
```

---

## 🔧 Servis Interface'leri

### IVillageService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task<IEnumerable<Village>> GetAllVillagesAsync()
Task<Village> GetVillageByIdAsync(int id)
Task<IEnumerable<Village>> GetVillagesNeedResourcesAsync()
Task<IEnumerable<Village>> GetVillagesWithFullStorageAsync()
Task ParseAndSyncAsync(string html)
```

---

### IWarfareService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task ScheduleAttackAsync(AttackTask task)
Task CancelAttackAsync(int taskId)
Task<IEnumerable<AttackTask>> GetActiveAttacksAsync()
```

---

### IEconomyService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task DistributeResourcesAsync()
Task MintCoinsAsync()
Task<EconomyViewModel> GetEconomyOverviewAsync()
```

---

### IMapScannerService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task<IEnumerable<Village>> FindTargetsNearAsync(int centerX, int centerY, int radius, int minPoints, int maxPoints)
Task ScanAreaAsync(int x, int y, int radius)
```

---

### IEmergencyService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
void TriggerKillSwitch()
void RevokeKillSwitch()
bool IsSystemLocked()
Task TriggerMassMilitiaAsync()
```

---

### IGameBrowserService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task LoginAsync()
Task<string> GetPageContentAsync(string page)
Task NavigateToVillageAsync(int villageId)
Task ExecuteAttackAsync(AttackTask task)
```

---

### IGroqAiService
**Namespace:** `TWA.Core.Interfaces.Services`

**Metodlar:**
```csharp
Task<string> AnalyzeGameStateAsync(string context)
Task<string> SuggestStrategyAsync(Village village)
```

---

## 🗄️ Veritabanı İşlemleri

### IUnitOfWork
**Namespace:** `TWA.Core.Interfaces`

**Metodlar:**
```csharp
IRepository<T> Repository<T>() where T : BaseEntity
Task<int> CommitAsync()
void Rollback()
```

### IRepository<T>
**Namespace:** `TWA.Core.Interfaces`

**Metodlar:**
```csharp
Task<T> GetByIdAsync(int id)
Task<IEnumerable<T>> GetAllAsync()
Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
Task AddAsync(T entity)
void Update(T entity)
void Delete(T entity)
```

---

## 📝 Enum Listesi

### VillageType
```csharp
Own = 1          // Bizim köyümüz
Barbarian = 2    // Barbar köy
Enemy = 3        // Düşman köyü
Ally = 4         // Müttefik köyü
```

### VillageMode
```csharp
Balanced         // Dengeli
Offensive        // Saldırı odaklı
Defensive        // Savunma odaklı
Farm             // Çiftlik (yağma)
Spy              // Casus
```

### AttackType
```csharp
Fake = 0         // Sahte saldırı
Farm = 1         // Yağma
Real_Nuke = 2    // Gerçek saldırı (nuke)
Real_Noble = 3   // Misyoner saldırısı
Snipe = 4        // Snipe (araya girme)
Support = 5      // Destek
```

### AttackStatus
```csharp
Pending = 0      // Beklemede
Scheduled = 1    // Zamanlandı
Sent = 2         // Gönderildi
Cancelled = 3    // İptal edildi
Failed = 4       // Başarısız
```

---

## 🔗 Routing Yapısı

**Default Route Pattern:** `{controller=Dashboard}/{action=Index}/{id?}`

**Tüm Panel Sayfaları:**
- `/Dashboard` - Ana kontrol paneli
- `/Attack` - Saldırı yönetimi
- `/Economy` - Ekonomi yönetimi
- `/Emergency` - Acil durum kontrolleri
- `/Garrison` - Garnizon yönetimi
- `/Infrastructure` - İnşaat yönetimi
- `/Map` - Harita radar
- `/Village` - Köy listesi ve detayları
- `/Warfare` - Savaş stratejileri

---

## 📡 Background Services

### AttackBackgroundService
**Namespace:** `TWA.Web.Workers`
**Görev:** Zamanlanmış saldırıları otomatik olarak yönetir

### LiveDataBroadcastService
**Namespace:** `TWA.Web.Workers`
**Görev:** SignalR üzerinden canlı veri yayını yapar

---

## 🔐 Konfigürasyon

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "PostgreSQL bağlantı dizesi"
  },
  "GameConfig": {
    "Url": "https://www.klanlar.org/",
    "Username": "Kullanıcı adı",
    "Password": "Şifre",
    "World": "tr99",
    "Headless": false
  },
  "Telegram": {
    "ApiKey": "Bot API key",
    "ChatId": "Chat ID"
  },
  "ApiKeys": {
    "XAiApiKey": "X.AI API key"
  }
}
```

---

## 📌 Notlar

1. **Tüm endpoint'ler** ASP.NET Core MVC pattern'ini takip eder
2. **SignalR** canlı veri güncellemeleri için kullanılır
3. **Background Services** otomatik görevler için çalışır
4. **Entity Framework Core** ORM olarak kullanılır
5. **PostgreSQL** veritabanı olarak kullanılır
6. **Selenium/Playwright** tarayıcı otomasyonu için kullanılır

---

**Oluşturulma Tarihi:** 2026-01-14
**Proje:** TWA Overlord - Tribal Wars Automation System
