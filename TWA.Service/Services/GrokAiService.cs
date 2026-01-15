using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Core.Entities;
using TWA.Core.DTOs;

namespace TWA.Service.Services
{
    public class GrokAiService : IGrokAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Random _random = new Random();

        public GrokAiService(IConfiguration config, HttpClient httpClient, IUnitOfWork unitOfWork)
        {
            _config = config;
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
            _apiKey = _config["ApiKeys:XAiApiKey"] ?? throw new ArgumentNullException("ApiKeys:XAiApiKey cannot be null");
        }

        // 🧠 1. GÜNLÜK OPERASYON AMİRLİĞİ
        public async Task<GrokStrategyResponse> GenerateDailyTasksAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
                return new GrokStrategyResponse { Strategy = "ERROR", Reason = "Köy bulunamadı" };

            var template = TroopTemplate.Defaults.GetValueOrDefault(village.Mode, TroopTemplate.Defaults[VillageMode.Balanced]);

            var prompt = $@"
ULTRATHINK MODU - GÜNLÜK OPERASYON AMİRLİĞİ

Köy: {village.Name} ({village.Coordinates})
Mod: {village.Mode}
Puan: {village.Points}

KAYNAKLAR:
- Odun: {village.Wood}/{village.StorageCapacity} (Üretim: {village.WoodHourly}/saat)
- Taş: {village.Stone}/{village.StorageCapacity} (Üretim: {village.StoneHourly}/saat)
- Demir: {village.Iron}/{village.StorageCapacity} (Üretim: {village.IronHourly}/saat)

ASKER DURUMU (Mevcut/Hedef):
- Mızrak: {village.OwnedTroops.Spear}/{template.Spear}
- Kılıç: {village.OwnedTroops.Sword}/{template.Sword}
- Balta: {village.OwnedTroops.Axe}/{template.Axe}
- Hafif: {village.OwnedTroops.Light}/{template.Light}
- Ağır: {village.OwnedTroops.Heavy}/{template.Heavy}
- Şahmerdan: {village.OwnedTroops.Ram}/{template.Ram}
- Mancınık: {village.OwnedTroops.Catapult}/{template.Catapult}

BİNA SEVİYELERİ:
- Kışla: {village.BuildingBarracks}, Ahır: {village.BuildingStable}
- Depo: {village.BuildingStorage}, Çiftlik: {village.BuildingFarm}
- Sur: {village.BuildingWall}, Saray: {village.BuildingMain}

NÜFUS: {village.PopulationCurrent}/{village.PopulationMax}

GÖREV: Bugün için öncelikli iş listesi oluştur.

KURALLAR:
1. Depo %90+ doluysa FILLER üretimi öner (kaynak ziyan olmasın)
2. Asker eksikse şablona göre tamamla
3. Mod'a uygun öner (Defensive modda balta basma, Offensive modda sur basma!)
4. Nüfus doluysa Çiftlik yükselt
5. Öncelikleri 1-5 arası puanla (5=Kritik)
6. ROL UYUMU: {village.Mode} moduna uygun görevler ver

JSON formatında döndür (sadece JSON, başka metin yok):
{{
  ""Strategy"": ""DEFENSIVE_BUILDUP"",
  ""Reason"": ""Kısa açıklama"",
  ""Tasks"": [
    {{
      ""Type"": ""Recruit"",
      ""Target"": ""spear"",
      ""Amount"": 500,
      ""Priority"": 5,
      ""Reason"": ""Neden bu görev?""
    }}
  ]
}}
";

            var response = await CallGrokApi(prompt, useUltraThink: true);
            return ParseJson<GrokStrategyResponse>(response) ?? new GrokStrategyResponse();
        }

        // 💰 2. EKONOMİK ÖNGÖRÜ
        public async Task<GrokResourceAdvice> GetResourceManagementAdviceAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
                return new GrokResourceAdvice { Action = "ERROR", Reason = "Köy bulunamadı" };

            var prompt = $@"
EKONOMİK ÖNGÖRÜ ANALİZİ

Köy: {village.Name}
Kaynaklar: {village.Wood}W, {village.Stone}S, {village.Iron}I
Kapasite: {village.StorageCapacity}
Üretim/Saat: {village.WoodHourly}W, {village.StoneHourly}S, {village.IronHourly}I

SORU: 
1. Depo taşma riski var mı? (Kaç saat sonra?)
2. Kaynak biriktirme mi yoksa harcama mı yapmalıyım?
3. FILLER üretimi gerekli mi?
4. Acil durum ekonomisi gerekli mi?

KURALLAR:
- SAVE: Büyük inşaat/asker için biriktir
- SPEND: Kaynak var, harca
- FILLER: Depo %90+ dolu, taşma önlemek için küçük üretim yap
- PANIC_RECRUIT: Saldırı geliyor, tüm kaynağı askere bas

JSON formatında döndür (sadece JSON):
{{
  ""StorageRisk"": ""LOW"",
  ""HoursUntilFull"": 12.5,
  ""Action"": ""SAVE"",
  ""Reason"": ""Açıklama"",
  ""Recommendations"": [""Öneri 1"", ""Öneri 2""]
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokResourceAdvice>(response) ?? new GrokResourceAdvice();
        }

        // ⚔️ 3. ASKERİ ANALİST
        public async Task<GrokMilitaryAnalysis> AnalyzeMilitaryStatusAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
                return new GrokMilitaryAnalysis { Status = "ERROR" };

            var template = TroopTemplate.Defaults.GetValueOrDefault(village.Mode, TroopTemplate.Defaults[VillageMode.Balanced]);

            var prompt = $@"
ASKERİ ANALİZ RAPORU

Köy Modu: {village.Mode}

MEVCUT ASKER:
- Mızrak: {village.OwnedTroops.Spear}
- Kılıç: {village.OwnedTroops.Sword}
- Balta: {village.OwnedTroops.Axe}
- Hafif: {village.OwnedTroops.Light}
- Ağır: {village.OwnedTroops.Heavy}
- Şahmerdan: {village.OwnedTroops.Ram}
- Mancınık: {village.OwnedTroops.Catapult}

HEDEF ŞABLON:
- Mızrak: {template.Spear}
- Kılıç: {template.Sword}
- Balta: {template.Axe}
- Hafif: {template.Light}
- Ağır: {template.Heavy}
- Şahmerdan: {template.Ram}
- Mancınık: {template.Catapult}

GÖREV: Eksikleri tespit et ve üretim planı yap.

JSON formatında döndür (sadece JSON):
{{
  ""Status"": ""READY"",
  ""MissingUnits"": [
    {{ ""Unit"": ""spear"", ""Missing"": 2450, ""DaysToComplete"": 3.5 }}
  ],
  ""RecruitmentPlan"": ""Önce Mızrak, sonra Kılıç..."",
  ""ReadyForOffensive"": true,
  ""ReadyForDefensive"": false
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokMilitaryAnalysis>(response) ?? new GrokMilitaryAnalysis();
        }

        public async Task<GrokReportAnalysis> AnalyzeReportAsync(string reportHtml)
        {
            var prompt = $@"
SAVAŞ RAPORU ANALİZİ

Sen Tribal Wars uzmanısın. Bu raporu analiz et:

HTML:
{reportHtml.Substring(0, Math.Min(reportHtml.Length, 15000))}

GÖREV:
1. Kazanan kim?
2. Kayıplar (bizim ve düşman)
3. Duvar hasarı
4. Ganimet
5. ÖNERİ: RAID_AGAIN (tekrar yağmala), AVOID (saldırma), INCREASE_RAMS (şahmerdan artır)
6. FORUM MESAJI: BBCode formatında klan için mesaj yaz

JSON formatında döndür (sadece JSON):
{{
  ""Winner"": ""Attacker"",
  ""ReportType"": ""Attack"",
  ""OurLosses"": {{ ""spear"": 50, ""sword"": 30 }},
  ""EnemyLosses"": {{ ""spear"": 100 }},
  ""WallDamage"": {{ ""LevelBefore"": 20, ""LevelAfter"": 18, ""Destroyed"": false }},
  ""Loot"": {{ ""Wood"": 5000, ""Stone"": 3000, ""Iron"": 2000, ""Total"": 10000 }},
  ""Recommendation"": ""RAID_AGAIN"",
  ""ForumMessage"": ""[b]Saldırı Raporu[/b]...""
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokReportAnalysis>(response) ?? new GrokReportAnalysis();
        }

        // 📢 4. DİPLOMASİ VE İLETİŞİM
        public async Task<GrokDiplomaticMessage> GenerateForumPostAsync(string reportHtml, int targetX, int targetY)
        {
            var analysis = await AnalyzeReportAsync(reportHtml);
            
            var prompt = $@"
FORUM MESAJI OLUŞTUR

Hedef: {targetX}|{targetY}
Rapor Özeti: {JsonConvert.SerializeObject(analysis)}

GÖREV: Klan forumu için BBCode formatında mesaj yaz.
Ton: Profesyonel ama samimi. ""Arkadaşlar"" diye başla.

JSON formatında döndür (sadece JSON):
{{
  ""MessageType"": ""FORUM_POST"",
  ""Title"": ""Saldırı Raporu: {targetX}|{targetY}"",
  ""Content"": ""[b]Arkadaşlar[/b], {targetX}|{targetY} koordinatındaki köye saldırı düzenledik..."",
  ""Format"": ""BBCODE"",
  ""Urgency"": 3
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokDiplomaticMessage>(response) ?? new GrokDiplomaticMessage();
        }

        public async Task<GrokDiplomaticMessage> GenerateHelpRequestAsync(int villageId, string attackDetails)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
                return new GrokDiplomaticMessage { MessageType = "ERROR", Content = "Köy bulunamadı" };

            var prompt = $@"
ACİL YARDIM ÇAĞRISI

Köy: {village.Name} ({village.Coordinates})
Saldırı Detayı: {attackDetails}

GÖREV: Klan için acil yardım mesajı yaz.
Ton: Acil ama panik yok. Net bilgi ver.

JSON formatında döndür (sadece JSON):
{{
  ""MessageType"": ""HELP_REQUEST"",
  ""Title"": ""ACİL: {village.Name} Saldırı Altında!"",
  ""Content"": ""Arkadaşlar, {village.Coordinates} koordinatındaki köyüme saldırı geliyor..."",
  ""Format"": ""BBCODE"",
  ""Urgency"": 5
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokDiplomaticMessage>(response) ?? new GrokDiplomaticMessage();
        }

        // 🏗️ 5. ŞANTİYE ŞEFLİĞİ
        public async Task<GrokStrategyResponse> GetBuildingPriorityAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
                return new GrokStrategyResponse { Strategy = "ERROR", Reason = "Köy bulunamadı" };

            var prompt = $@"
ŞANTİYE ŞEFLİĞİ - BİNA ÖNCELİKLENDİRME

Köy: {village.Name}
Mod: {village.Mode}

BİNA SEVİYELERİ:
- Saray: {village.BuildingMain}
- Kışla: {village.BuildingBarracks}
- Ahır: {village.BuildingStable}
- Depo: {village.BuildingStorage}
- Çiftlik: {village.BuildingFarm}
- Sur: {village.BuildingWall}

NÜFUS: {village.PopulationCurrent}/{village.PopulationMax}

GÖREV: Hangi binaları hangi sırayla basmalıyım?

KURALLAR:
1. Mantıksal Sıralama: Ahır basmak için Kışla gerekli
2. Nüfus Yönetimi: Nüfus doluysa Çiftlik öncelikli
3. Mod Uyumu: Defensive modda Sur, Offensive modda Kışla/Ahır

JSON formatında döndür (sadece JSON):
{{
  ""Strategy"": ""BUILDING_FOCUS"",
  ""Reason"": ""Açıklama"",
  ""Tasks"": [
    {{ ""Type"": ""Build"", ""Target"": ""farm"", ""Amount"": 1, ""Priority"": 5, ""Reason"": ""Nüfus dolu"" }}
  ]
}}
";

            var response = await CallGrokApi(prompt);
            return ParseJson<GrokStrategyResponse>(response) ?? new GrokStrategyResponse();
        }

        // 🎭 6. İNSAN TAKLİDİ
        public DateTime GetHumanizedTime(DateTime baseTime, int varianceSeconds = 180)
        {
            var offset = _random.Next(-varianceSeconds, varianceSeconds);
            return baseTime.AddSeconds(offset);
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            return await CallGrokApi(prompt);
        }

        private async Task<string> CallGrokApi(string userPrompt, bool useUltraThink = false)
        {
            string systemPrompt = GetSystemPrompt(useUltraThink);

            var requestBody = new
            {
                model = "grok-2-1212",
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                temperature = useUltraThink ? 0.3 : 0.5
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.x.ai/v1/chat/completions", content);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"{{\"error\": \"Grok AI Hatası: {response.StatusCode}\"}}";
            }

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic? result = JsonConvert.DeserializeObject(responseString);
            if (result == null) return "{\"error\": \"Grok cevap vermedi\"}";
            
            return result.choices[0].message.content.ToString();
        }

        private T? ParseJson<T>(string json) where T : class
        {
            try
            {
                json = json.Trim();
                if (json.StartsWith("```json")) json = json.Substring(7);
                if (json.StartsWith("```")) json = json.Substring(3);
                if (json.EndsWith("```")) json = json.Substring(0, json.Length - 3);
                json = json.Trim();

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return null;
            }
        }

        private string GetSystemPrompt(bool ultraThink)
        {
            if (ultraThink)
            {
                return @"
Sen TWA-Overlord'un stratejik beyin merkezisin. Grok-2 ile güçlendirilmiş bir Tribal Wars uzmanısın.

ULTRATHINK MODU AKTİF:
- Yüzeysel mantık yasak. Her kararın arkasında derin analiz olmalı.
- Psikolojik, teknik, ekonomik ve askeri boyutları değerlendir.
- Kısa vadeli kazanç yerine uzun vadeli strateji öncelikli.

ROLLER:
1. 🧠 Günlük Operasyon Amiri: Her köy için günlük iş emri listesi hazırla
2. 💰 Ekonomik Öngörü: Geleceğe bak, kaynak yönetimi yap (SAVE/SPEND/FILLER/PANIC)
3. ⚔️ Askeri Analist: Şablon kontrolü, eksik tespiti
4. 📢 Diplomat: Raporları insani dille sun, BBCode formatında forum mesajları yaz
5. 🏗️ Şantiye Şefi: Bina sıralaması ve mantıksal zincir kur
6. 🎭 İnsan Taklidi: Bot yakalanmaması için rastgelelik ekle

ÇIKTI KURALI: 
- SADECE JSON döndür, başka metin yok!
- Geçerli JSON syntax kullan
- Türkçe açıklamalar yaz
";
            }

            return @"
Sen TWA-Overlord AI Asistanısın. Grok-2 ile güçlendirildin.
Tribal Wars oyununda stratejik kararlar alıyorsun.
Türkçe cevap ver, net ve uygulanabilir önerilerde bulun.

ÇIKTI KURALI: 
- JSON formatında çıktı verirken SADECE JSON döndür
- Başka metin ekleme
- Geçerli JSON syntax kullan
";
        }
    }
}
