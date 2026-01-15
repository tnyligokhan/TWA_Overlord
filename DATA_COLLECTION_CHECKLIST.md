# 📊 VERİ TOPLAMA KONTROL LİSTESİ

Bu belge projedeki veri çekme işlemlerinin durumunu gösterir.

**Durum Göstergeleri:**
- ✅ **Tam İmplementasyon:** Parsing + Veritabanı + UI
- 🔄 **Kısmi İmplementasyon:** Parsing var, UI eksik veya tam tersi
- ⏳ **Planlanan:** Dokümante edilmiş, kod yok
- ❌ **Başlanmadı:** Ne kod ne dokümantasyon

---

## ✅ TAMAMLANAN ÖZELLİKLER

### 1️⃣ GENEL BAKIŞ (Overview)
**URL:** `game.php?village={id}&screen=overview`

**Çekilen Veriler:**
- Kaynaklar: `game_data.village.wood/stone/iron/storage_max`
- Saatlik Üretim: Regex ile `Odun/Kil/Demir ... saat başına`
- Nüfus: `game_data.village.pop/pop_max`
- Koordinatlar: `game_data.village.x/y/name/points`

**Servisler:**
- `VillageDataSyncService.SyncResourcesAndPopulationAsync()`
- `HtmlParsingService.ParseHourlyProduction()`

**Veritabanı:** `Village` entity (Wood, Stone, Iron, WoodHourly, StoneHourly, IronHourly, PopulationCurrent, PopulationMax, CoordinateX, CoordinateY, Points)

**UI:** Dashboard ve Village Details sayfalarında gösteriliyor

---

### 2️⃣ ANA BİNA (Main)
**URL:** `game.php?village={id}&screen=main`

**Çekilen Veriler:**
- Bina Seviyeleri: `<tr id="main_buildrow_{building_type}">` → Regex `Seviye (\d+)`
- İnşaat Kuyruğu: `<tbody id="buildqueue">` → `buildorder_{building_type}` class + `data-endtime`

**Servisler:**
- `VillageDataSyncService.SyncBuildingLevelsAsync()`
- `HtmlParsingService.ParseBuildingLevels()`
- `HtmlParsingService.ParseBuildQueue()`

**Veritabanı:** `Village` entity (BuildingMain, BuildingBarracks, BuildingStable, BuildingGarage, BuildingSnob, BuildingSmithy, BuildingStatue, BuildingWood, BuildingStone, BuildingIron, BuildingFarm, BuildingStorage, BuildingWall, BuildQueueJson)

**UI:** Village Details sayfasında gösteriliyor

---

### 3️⃣ İÇTİMA MEYDANI (Place)
**URL:** `game.php?village={id}&screen=place`

**Çekilen Veriler:**
- Asker Sayıları: `<td class="unit-item unit-item-{unit_type}">{count}</td>` → Regex `unit-item-{unit_type}[^>]*>(\d+)<`

**Servisler:**
- `VillageDataSyncService.SyncTroopsAsync()`
- `VillageDataSyncService.ParseTroopCount()` (private method)

**Veritabanı:** `Village.OwnedTroops` (TroopSet: Spear, Sword, Axe, Spy, Light, Heavy, Ram, Catapult, Knight, Snob)

**UI:** Village Details ve Garrison sayfalarında gösteriliyor

---

### 4️⃣ DEMİRCİ (Smithy)
**URL:** `game.php?village={id}&screen=smith`

**Çekilen Veriler:**
- Araştırma Seviyeleri: JavaScript `BuildingSmith.techs = {"available":{"unit":{"level":"X"}}}` → İki aşamalı regex parsing
- Seviyeler: 0 (Araştırılmamış) veya 1 (Araştırıldı)

**Servisler:**
- `VillageDataSyncService.SyncResearchLevelsAsync()`
- `HtmlParsingService.ParseResearchLevels()`

**Veritabanı:** `Village` entity (ResearchSpear, ResearchSword, ResearchAxe, ResearchSpy, ResearchLight, ResearchHeavy, ResearchRam, ResearchCatapult)

**UI:** `/Building/Smithy` sayfası + Recruitment sayfalarında araştırma kontrolü

---

### 5️⃣ ASKER ÜRETİMİ (Train)
**URL:** `game.php?village={id}&screen=train`

**Çekilen Veriler:**
- Üretim Kuyrukları: `<tbody id="trainqueue_{building}">` → Aktif (class="lit") + Bekleyen satırlar
- Birim tipi: `<div class="unit_sprite ... {unit_type}">`
- Miktar: Regex `(\d+)\s+` (ilk td)
- Bitiş zamanı: Türkçe tarih formatı parse ("bugün saat HH:mm:ss", "yarın saat HH:mm:ss")

**Servisler:**
- `VillageDataSyncService.SyncRecruitmentQueuesAsync()`
- `HtmlParsingService.ParseRecruitmentQueue()`
- `HtmlParsingService.ParseRecruitmentRow()` (private)
- `HtmlParsingService.ParseTurkishDateTime()` (private)

**Veritabanı:** `Village` entity (BarracksQueueJson, StableQueueJson, GarageQueueJson, SnobQueueJson)

**UI:** `/Recruitment/Barracks`, `/Recruitment/Stable`, `/Recruitment/Garage`, `/Recruitment/Snob` sayfaları

---

## 🔄 KISMİ İMPLEMENTASYON

### 6️⃣ KOMUTLAR (Commands)
**URL:** `game.php?village={id}&screen=overview_villages&mode=commands`

**Çekilen Veriler:**
- Komut türleri: `&type=all/attack/support/return`
- Komut tablosu: `<table id="commands_table">` veya `<table class="vis">`
- Komut ikonları: attack_small/medium/large, farm, snob, spy, knight

**Servisler:** ✅ `HtmlParsingService.ParseCommands()`

**Veritabanı:** ✅ `Command` entity

**UI:** ✅ `/Commands/Index` controller var ama boş liste döndürüyor

**Eksikler:**
- [x] `HtmlParsingService.ParseCommands()` metodu yazılmalı
- [x] `Command` entity oluşturulmalı
- [x] `VillageDataSyncService.SyncCommandsAsync()` eklenmeli

---

### 7️⃣ PAZAR (Market)
**URL:** `game.php?village={id}&screen=market`

**Çekilen Veriler:**
- Tüccar durumu: JavaScript `Data.Trader.amount/total/carry` veya HTML `<span id="market_merchant_*">`
- Ticaret teklifleri: `<table class="vis">` → Alacağın, Vereceğin, Oyuncu, Süre, Oran
- Pazar modları: `&mode=other_offer/own_offer/send/transports/traders`

**Servisler:** ✅ `HtmlParsingService.ParseTradeOffers()`, `ParseAvailableMerchants()`

**Veritabanı:** ✅ `TradeOffer` and `Village.Merchants`

**UI:** ✅ `/Market/Index` ve `/Market/Transports` var ama boş liste döndürüyor

**Eksikler:**
- [x] `HtmlParsingService.ParseMarketData()` metodu yazılmalı (ParseTradeOffers olarak eklendi)
- [x] `TradeOffer` ve `Transport` entity'leri oluşturulmalı
- [x] `VillageDataSyncService.SyncMarketAsync()` eklenmeli

---

### 8️⃣ RAPORLAR (Reports)
**URL:** `game.php?village={id}&screen=report`

**Çekilen Veriler:**
- Rapor türleri: `&mode=all/attack/defense/support/trade/event/other`
- Rapor listesi: `<table id="report_list">` → `<tr class="report-{id}">`
- Rapor detayları: Konu, tarih, ikon, savaş sonucu (green/yellow/red/blue dots)
- Yağma durumu: `max_loot/{level}.webp`

**Servisler:** ✅ `HtmlParsingService.ParseReports()`

**Veritabanı:** ✅ `Report` entity

**UI:** ✅ `/Reports/Index` ve `/Reports/Details` var ama boş liste döndürüyor

**Eksikler:**
- [x] `HtmlParsingService.ParseReports()` metodu yazılmalı
- [x] `Report` entity oluşturulmalı
- [x] `VillageDataSyncService.SyncReportsAsync()` eklenmeli

---

## ⏳ PLANLANAN ÖZELLİKLER

### 9️⃣ HARİTA (Map)
**URL:** `game.php?village={id}&screen=map`

**Çekilen Veriler:**
- Köy bilgileri: JavaScript `TWMap.sectorPrefech[].data.villages`
- Oyuncu bilgileri: JavaScript `TWMap.sectorPrefech[].data.players`
- Klan bilgileri: JavaScript `TWMap.sectorPrefech[].data.allies`

**Servisler:** ✅ `HtmlParsingService.ParseMapData()`, `MapScannerService.ScanAndSaveBarbariansAsync()`

**Veritabanı:** ✅ `Village` entity (Barbarlar `MapScannerService` ile kaydediliyor)

**UI:** ✅ `/Map/Index` var

**Eksikler:**
- [x] `MapParser` implemente edildi (`TWMap.sectorPrefech` JSON parsing)
- [x] `VillageDataSyncService.SyncMapAsync` eklendi
- [x] `MapScannerService` entegrasyonu tamamlandı

---

### 1️⃣0️⃣ ENVANTER (Inventory)
**URL:** `game.php?village={id}&screen=inventory`

**Çekilen Veriler:**
- Envanter kategorileri: JavaScript `Inventory.item_categories` (7 kategori)
- Öğe türleri: JavaScript `Inventory.item_types` (4 tür)
- Öğe listesi: `<div class="inventory_items">` → `<div id="item_{id}_{index}">`

**Servisler:** ✅ `HtmlParsingService.ParseInventory()`
✅ `VillageDataSyncService.SyncInventoryAsync`

**Veritabanı:** ✅ `InventoryItem` entity

**UI:** ✅ `/Inventory/Index`

---

### 1️⃣1️⃣ BAYRAKLAR (Flags)
**URL:** `game.php?village={id}&screen=flags`

**Çekilen Veriler:** `InventoryParser.ParseFlags` ile çekiliyor.

**Servisler:** ✅ `HtmlParsingService.ParseFlags()`
✅ `VillageDataSyncService.SyncFlagsAsync()`

**Veritabanı:** ✅ `Flag` entity

**UI:** ✅ `/Flags/Index`

---

### 1️⃣2️⃣ ŞÖVALYE (Knight/Statue)
**URL:** `game.php?village={id}&screen=statue`

**Çekilen Veriler:**
- Heykel seviyesi: `<h2>Heykel (seviye {level})</h2>` → Regex `Heykel \(seviye (\d+)\)`
- Şövalye durumu: `<table class="vis">` → "Şövalye bu köyde bulunuyor" / "Şövalye başka bir köyde"
- Şövalye ismi: `<input type="text" name="knights_name" value="{name}">`

**Servisler:** ✅ `HtmlParsingService.ParseKnightName()`, `IsKnightInVillage()`
✅ `VillageDataSyncService.SyncKnightAsync()`

**Veritabanı:** ✅ `Village.KnightName`, `Village.IsKnightLocal`

**UI:** ✅ `/Knight/Index`

---

## 🔧 MEVCUT SERVİSLER

### HtmlParsingService
✅ `ParseBuildingLevels(html)` → Bina seviyeleri
✅ `ParseBuildQueue(html)` → İnşaat kuyruğu
✅ `ParseRecruitmentQueue(html, building)` → Üretim kuyruğu
✅ `ParseResearchLevels(html)` → Araştırma seviyeleri
✅ `ParseHourlyProduction(html)` → Saatlik üretim
✅ `ParseCommands(html)` → Komutlar
✅ `ParseTradeOffers(html)` / `ParseAvailableMerchants` → Pazar verileri
✅ `ParseReports(html)` → Raporlar
✅ `ParseKnightName(html)` / `IsKnightInVillage` → Şövalye
✅ `ParseMapData(html)` → Harita verileri
✅ `ParseInventory(html)` → Envanter
✅ `ParseFlags(html)` → Bayraklar


### VillageDataSyncService
✅ `SyncBuildingLevelsAsync()` → Main sayfası
✅ `SyncResourcesAndPopulationAsync()` → Overview sayfası
✅ `SyncTroopsAsync()` → Place sayfası
✅ `SyncResearchLevelsAsync()` → Smithy sayfası
✅ `SyncRecruitmentQueuesAsync()` → Train sayfası
✅ `SyncCommandsAsync()` → Commands
✅ `SyncMarketAsync()` → Market
✅ `SyncReportsAsync()` → Reports
✅ `SyncKnightAsync()` → Knight
✅ `SyncMapAsync()` → Map
✅ `SyncInventoryAsync()` → Inventory
✅ `SyncFlagsAsync()` → Flags


### GameBrowserService
✅ `GetPageContentAsync(screen)` → Sayfa HTML'i
✅ `GetGameDataIntAsync(path)` → JavaScript değişkeni
✅ `GetGameDataStringAsync(path)` → JavaScript string

---

## 📊 İMPLEMENTASYON İSTATİSTİKLERİ

**Toplam Özellik:** 12
**Tamamlanan:** 12 (100%)
**Kısmi:** 0 (0%)
**Planlanan:** 0 (0%)

**Parsing Metodları:** 12/12 (100%)
**Sync Metodları:** 12/12 (100%)
**UI Sayfaları:** 12/12 (100%)
**Veritabanı:** 12/12 (100%)
