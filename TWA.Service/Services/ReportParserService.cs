using HtmlAgilityPack;
using System.Linq;

namespace TWA.Service.Services
{
    public class ReportParserService
    {
        public ReportAnalysisResult AnalyzeReport(string htmlContent)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
            var result = new ReportAnalysisResult();

            // 1. SAVAŞ SONUCU (Yeşil/Sarı/Kırmızı Nokta)
            var dotNode = doc.DocumentNode.SelectSingleNode("//img[contains(@src, 'graphic/dots/')]");
            if (dotNode != null)
            {
                string src = dotNode.GetAttributeValue("src", "");
                if (src.Contains("green")) result.Status = ReportStatus.Victory;
                else if (src.Contains("yellow")) result.Status = ReportStatus.Casualties;
                else if (src.Contains("red")) result.Status = ReportStatus.Defeat;
                else if (src.Contains("blue")) result.Status = ReportStatus.Scouted;
            }

            // 2. YAĞMA DURUMU (Çuval İkonu)
            // 1.webp = Tam Yağma (Depo doldu, askerler daha fazlasını taşıyamadı -> TEKRAR SALDIR!)
            var lootNode = doc.DocumentNode.SelectSingleNode("//img[contains(@src, 'graphic/max_loot/1.webp')]");
            result.IsFullLoot = (lootNode != null);

            // 3. CASUS BİLGİSİ (Bina Seviyeleri)
            // Tablodaki bina seviyelerini çekip veritabanındaki "EnemyVillage" kaydını güncelleyeceğiz.
            var buildingsText = doc.DocumentNode.InnerText; 
            if (buildingsText.Contains("Casuslanan hammaddeler"))
            {
                // Regex ile bina seviyelerini ayıkla (Örn: "Ana bina 20, Kışla 15")
                // result.ScoutedBuildings = ParseBuildings(buildingsText);
            }

            return result;
        }
    }

    public class ReportAnalysisResult
    {
        public ReportStatus Status { get; set; }
        public bool IsFullLoot { get; set; }
        // Diğer veriler...
    }
    
    public enum ReportStatus { Victory, Casualties, Defeat, Scouted }
}
