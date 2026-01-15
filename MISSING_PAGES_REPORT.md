# TWA OVERLORD - EKSİK SAYFALAR VE BUTONLAR RAPORU

## 📊 MEVCUT SAYFALAR

### ✅ Var Olan Controller ve View'lar:
1. **Dashboard** (`/Dashboard/Index`) ✅
   - Controller: ✅ DashboardController.cs
   - View: ✅ Dashboard/Index.cshtml
   - Menü: ✅ KOMUTA MERKEZİ

2. **Village** (`/Village/Index`, `/Village/Details/{id}`) ✅
   - Controller: ✅ VillageController.cs
   - Views: ✅ Village/Index.cshtml, Village/Details.cshtml
   - Menü: ✅ KÖY YÖNETİMİ

3. **Infrastructure** (`/Infrastructure/Index`) ✅
   - Controller: ✅ InfrastructureController.cs
   - View: ✅ Infrastructure/Index.cshtml
   - Menü: ✅ ALTYAPI

4. **Garrison** (`/Garrison/Index`) ✅
   - Controller: ✅ GarrisonController.cs
   - View: ✅ Garrison/Index.cshtml
   - Menü: ✅ GARNİZON

5. **Warfare** (`/Warfare/Index`) ✅
   - Controller: ✅ WarfareController.cs
   - View: ✅ Warfare/Index.cshtml
   - Menü: ✅ SAVAŞ ODASI

6. **Map** (`/Map/Index`) ✅
   - Controller: ✅ MapController.cs
   - View: ✅ Map/Index.cshtml
   - Menü: ✅ RADAR & HARİTA

7. **Economy** (`/Economy/Index`) ✅
   - Controller: ✅ EconomyController.cs
   - View: ✅ Economy/Index.cshtml
   - Menü: ✅ EKONOMİ

8. **Emergency** (`/Emergency/Index`) ✅
   - Controller: ✅ EmergencyController.cs
   - View: ✅ Emergency/Index.cshtml
   - Menü: ✅ ACİL DURUM

9. **Attack** (`/Attack/Index`) ✅
   - Controller: ✅ AttackController.cs
   - View: ✅ Attack/Index.cshtml
   - Menü: ❌ YOK (Warfare altında olmalı)

---

## ❌ EKSİK SAYFALAR VE ÖZELLİKLER

### 1. ASKER BASMA (RECRUITMENT) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Kışla, Ahır, Atölye için asker basma sayfaları

**Oluşturulması Gerekenler:**
```
Controller: RecruitmentController.cs
Views:
  - Recruitment/Barracks.cshtml (Kışla - Piyade)
  - Recruitment/Stable.cshtml (Ahır - Süvari)
  - Recruitment/Garage.cshtml (Atölye - Kuşatma)
  - Recruitment/Snob.cshtml (Akademi - Misyoner)

Routes:
  - /Recruitment/Barracks
  - /Recruitment/Stable
  - /Recruitment/Garage
  - /Recruitment/Snob
```

**Menü Önerisi:** Garrison altında "Asker Bas" butonu

---

### 2. PAZAR (MARKET) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Kaynak taşıma ve lojistik yönetimi

**Oluşturulması Gerekenler:**
```
Controller: MarketController.cs
Views:
  - Market/Index.cshtml (Kaynak gönderme)
  - Market/Incoming.cshtml (Gelen sevkiyatlar)
  - Market/Outgoing.cshtml (Giden sevkiyatlar)

Routes:
  - /Market/Index
  - /Market/SendResources
  - /Market/Incoming
  - /Market/Outgoing
```

**Menü Önerisi:** Economy altında "Pazar & Lojistik" butonu

---

### 3. RAPORLAR (REPORTS) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Savaş raporları, casus raporları, ticaret raporları

**Oluşturulması Gerekenler:**
```
Controller: ReportsController.cs
Views:
  - Reports/Index.cshtml (Tüm raporlar)
  - Reports/Attack.cshtml (Saldırı raporları)
  - Reports/Defense.cshtml (Savunma raporları)
  - Reports/Support.cshtml (Destek raporları)
  - Reports/Trade.cshtml (Ticaret raporları)
  - Reports/Details/{id}.cshtml (Rapor detayı)

Routes:
  - /Reports/Index
  - /Reports/Attack
  - /Reports/Defense
  - /Reports/Support
  - /Reports/Trade
  - /Reports/Details/{id}
```

**Menü Önerisi:** Ana menüde "RAPORLAR" butonu

---

### 4. DEMİRCİ (SMITHY) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Asker geliştirme (upgrade) sistemi

**Oluşturulması Gerekenler:**
```
Controller: SmithyController.cs
Views:
  - Smithy/Index.cshtml (Geliştirme listesi)
  - Smithy/Upgrade.cshtml (Geliştirme formu)

Routes:
  - /Smithy/Index
  - /Smithy/Upgrade
```

**Menü Önerisi:** Infrastructure altında "Demirci" butonu

---

### 5. AKADEMİ (ACADEMY) SAYFASI
**Durum:** ❌ Eksik (Sadece Minting var)
**Gerekli:** Altın basma, misyoner basma, araştırma

**Oluşturulması Gerekenler:**
```
Controller: AcademyController.cs
Views:
  - Academy/Index.cshtml (Genel bakış)
  - Academy/MintCoins.cshtml (Altın basma)
  - Academy/TrainNoble.cshtml (Misyoner basma)

Routes:
  - /Academy/Index
  - /Academy/MintCoins
  - /Academy/TrainNoble
```

**Menü Önerisi:** Infrastructure altında "Akademi" butonu

---

### 6. AYARLAR (SETTINGS) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Oyun ayarları, bot ayarları, profil

**Oluşturulması Gerekenler:**
```
Controller: SettingsController.cs
Views:
  - Settings/Index.cshtml (Genel ayarlar)
  - Settings/Game.cshtml (Oyun ayarları)
  - Settings/Bot.cshtml (Bot ayarları)
  - Settings/Profile.cshtml (Profil)

Routes:
  - /Settings/Index
  - /Settings/Game
  - /Settings/Bot
  - /Settings/Profile
```

**Menü Önerisi:** Sidebar altında "AYARLAR" butonu

---

### 7. GRUPLAR (GROUPS) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Köy grupları yönetimi

**Oluşturulması Gerekenler:**
```
Controller: GroupsController.cs
Views:
  - Groups/Index.cshtml (Grup listesi)
  - Groups/Create.cshtml (Grup oluştur)
  - Groups/Edit/{id}.cshtml (Grup düzenle)
  - Groups/Assign.cshtml (Köy ata)

Routes:
  - /Groups/Index
  - /Groups/Create
  - /Groups/Edit/{id}
  - /Groups/Assign
```

**Menü Önerisi:** Village altında "Gruplar" butonu

---

### 8. KOMUTLAR (COMMANDS) SAYFASI
**Durum:** ❌ Eksik (Warfare'de kısmi var)
**Gerekli:** Tüm komutları görüntüleme ve yönetme

**Oluşturulması Gerekenler:**
```
Controller: CommandsController.cs
Views:
  - Commands/Index.cshtml (Tüm komutlar)
  - Commands/Outgoing.cshtml (Giden komutlar)
  - Commands/Incoming.cshtml (Gelen komutlar)
  - Commands/Details/{id}.cshtml (Komut detayı)

Routes:
  - /Commands/Index
  - /Commands/Outgoing
  - /Commands/Incoming
  - /Commands/Details/{id}
```

**Menü Önerisi:** Warfare altında "Komutlar" butonu

---

### 9. İSTATİSTİKLER (STATISTICS) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Oyuncu istatistikleri, köy istatistikleri, sıralama

**Oluşturulması Gerekenler:**
```
Controller: StatisticsController.cs
Views:
  - Statistics/Index.cshtml (Genel istatistikler)
  - Statistics/Player.cshtml (Oyuncu istatistikleri)
  - Statistics/Villages.cshtml (Köy istatistikleri)
  - Statistics/Tribe.cshtml (Kabile istatistikleri)

Routes:
  - /Statistics/Index
  - /Statistics/Player
  - /Statistics/Villages
  - /Statistics/Tribe
```

**Menü Önerisi:** Ana menüde "İSTATİSTİKLER" butonu

---

### 10. KABILE (TRIBE) SAYFASI
**Durum:** ❌ Eksik
**Gerekli:** Kabile yönetimi, üye listesi, forum

**Oluşturulması Gerekenler:**
```
Controller: TribeController.cs
Views:
  - Tribe/Index.cshtml (Kabile genel bakış)
  - Tribe/Members.cshtml (Üye listesi)
  - Tribe/Forum.cshtml (Forum)
  - Tribe/Settings.cshtml (Kabile ayarları)

Routes:
  - /Tribe/Index
  - /Tribe/Members
  - /Tribe/Forum
  - /Tribe/Settings
```

**Menü Önerisi:** Ana menüde "KABİLE" butonu

---

## 🔧 EKSİK BUTONLAR VE FONKSİYONLAR

### Dashboard Sayfası:
- ❌ "Tüm Köyleri Senkronize Et" butonu
- ❌ "Otomatik Mod Başlat/Durdur" butonu
- ❌ "Acil Durum Modu" hızlı erişim
- ❌ "Son Raporlar" widget'ı
- ❌ "Gelen Saldırılar" widget'ı (var ama detay yok)

### Village Sayfası:
- ❌ "Toplu İşlem" butonları (Toplu inşaat, toplu asker basma)
- ❌ "Köy Şablonu Uygula" butonu
- ❌ "Köy Notları" bölümü
- ❌ "Köy Geçmişi" (log) bölümü

### Infrastructure Sayfası:
- ❌ "Otomatik İnşaat Planı" butonu
- ❌ "Tüm Köylerde Aynı Binayı Geliştir" butonu
- ❌ "İnşaat Şablonu Kaydet/Yükle" butonu

### Garrison Sayfası:
- ❌ "Asker Bas" butonu (Recruitment sayfasına yönlendirme)
- ❌ "Toplu Asker Basma" butonu
- ❌ "Asker Şablonu Uygula" butonu
- ❌ "Asker Dağıtımı" (köyler arası asker transferi)

### Warfare Sayfası:
- ❌ "Toplu Saldırı Planla" butonu
- ❌ "Snipe Hesaplayıcı" widget'ı
- ❌ "Fake Train" (sahte saldırı treni) butonu
- ❌ "Saldırı Şablonu Kaydet/Yükle" butonu

### Map Sayfası:
- ❌ "Hedef Ara" (koordinat, oyuncu adı, kabile)
- ❌ "Barbar Tarama" butonu
- ❌ "Yakındaki Düşmanlar" butonu
- ❌ "Harita İşaretle" (bookmark) butonu

### Economy Sayfası:
- ❌ "Otomatik Kaynak Dağıtımı" butonu (var ama UI eksik)
- ❌ "Altın Basma" butonu (var ama UI eksik)
- ❌ "Tüccar Rotaları" görüntüleme
- ❌ "Kaynak Tahmini" (gelecek kaynak durumu)

### Emergency Sayfası:
- ❌ "Toplu Savunma Modu" butonu
- ❌ "Tüm Saldırıları İptal Et" butonu
- ❌ "Acil Kaynak Transferi" butonu
- ❌ "Telegram Bildirimi Gönder" butonu

---

## 📋 ÖNCELİK SIRASI

### Yüksek Öncelik (Kritik):
1. **Recruitment (Asker Basma)** - Oyunun temel özelliği
2. **Market (Pazar)** - Kaynak yönetimi için gerekli
3. **Reports (Raporlar)** - Savaş sonuçlarını görmek için
4. **Commands (Komutlar)** - Aktif komutları izlemek için

### Orta Öncelik:
5. **Smithy (Demirci)** - Asker geliştirme
6. **Academy (Akademi)** - Misyoner ve altın
7. **Statistics (İstatistikler)** - Performans takibi
8. **Settings (Ayarlar)** - Konfigürasyon

### Düşük Öncelik:
9. **Groups (Gruplar)** - Köy organizasyonu
10. **Tribe (Kabile)** - Sosyal özellikler

---

## 🎯 ÖNERİLEN YENİ MENÜ YAPISI

```
SIDEBAR MENU:
├── 🏠 KOMUTA MERKEZİ (Dashboard)
├── 🏰 KÖY YÖNETİMİ (Village)
│   ├── Köy Listesi
│   ├── Köy Detayları
│   └── Gruplar
├── 🏗️ ALTYAPI (Infrastructure)
│   ├── İnşaat Kuyruğu
│   ├── Demirci
│   └── Akademi
├── 🛡️ GARNİZON (Garrison)
│   ├── Asker Durumu
│   └── Asker Bas (Recruitment)
├── ⚔️ SAVAŞ ODASI (Warfare)
│   ├── Saldırı Planla
│   ├── Komutlar
│   └── Raporlar
├── 🗺️ RADAR & HARİTA (Map)
│   ├── Harita
│   ├── Hedef Ara
│   └── Barbar Tarama
├── 💰 EKONOMİ (Economy)
│   ├── Kaynak Durumu
│   ├── Pazar & Lojistik
│   └── Altın Basma
├── 📊 İSTATİSTİKLER (Statistics)
│   ├── Oyuncu
│   ├── Köyler
│   └── Kabile
├── 👥 KABİLE (Tribe)
│   ├── Genel Bakış
│   ├── Üyeler
│   └── Forum
├── ⚙️ AYARLAR (Settings)
│   ├── Oyun Ayarları
│   ├── Bot Ayarları
│   └── Profil
└── 🚨 ACİL DURUM (Emergency)
```

---

## 📝 SONUÇ

**Toplam Eksik Sayfa:** 10 ana sayfa
**Toplam Eksik Buton/Özellik:** 30+ özellik
**Tahmini Geliştirme Süresi:** 
- Yüksek Öncelik: 2-3 hafta
- Orta Öncelik: 2 hafta
- Düşük Öncelik: 1 hafta

**Toplam:** 5-6 hafta (tam zamanlı çalışma ile)

---

**Rapor Tarihi:** 2026-01-14
**Proje:** TWA Overlord - Tribal Wars Automation System
