using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class GroqAiService : IGroqAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public GroqAiService(IConfiguration config, HttpClient httpClient, IUnitOfWork unitOfWork)
        {
            _config = config;
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
            _apiKey = _config["ApiKeys:GroqApiKey"] ?? throw new ArgumentNullException("ApiKeys:GroqApiKey cannot be null");
        }

        public async Task<string> AnalyzeReportAsync(string reportHtml)
        {
            var prompt = $@"
            Sen Tribal Wars (Klanlar) oyunu için uzman bir savaş analistisin.
            Aşağıdaki HTML raporunu analiz et ve JSON formatında şu bilgileri ver:
            1. Kazanan kim?
            2. Bizim kayıplarımız (Birim bazında).
            3. Düşman kayıpları.
            4. Duvar yıkıldı mı? Kaçtan kaça düştü?
            5. Ganimet durumu.
            
            HTML:
            {reportHtml.Substring(0, Math.Min(reportHtml.Length, 15000))} 
            "; // HTML çok uzunsa kesiyoruz, Groq limiti için.

            return await CallGroqApi(prompt);
        }

        public async Task<string> GetStrategySuggestionAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Core.Entities.Village>().GetByIdAsync(villageId);
            if (village == null) return "AI Hatası: Köy bulunamadı.";
            
            var prompt = $@"
            Köy Durumu:
            Puan: {village.Points}
            Sadakat: {village.Loyalty}
            Depo: {village.Wood}/{village.StorageCapacity} Wood, {village.Stone} Stone, {village.Iron} Iron.
            Asker: {village.OwnedTroops.Spear} Mızrak, {village.OwnedTroops.Sword} Kılıç, {village.OwnedTroops.Axe} Balta, {village.OwnedTroops.Light} Hafif.
            
            Bu köy için ne yapmalıyım?
            Seçenekler: 'Savunma Bas', 'Saldırı Bas', 'Depo Yükselt', 'Misyoner Bas'.
            Sadece tek bir strateji öner ve nedenini 1 cümle ile açıkla.
            ";

            return await CallGroqApi(prompt);
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            // Genel sohbet cevapları için
            return await CallGroqApi(prompt);
        }

        private async Task<string> CallGroqApi(string userPrompt)
        {
            string systemPrompt;
            try
            {
                var promptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SystemPrompts.txt");
                systemPrompt = File.Exists(promptPath) 
                    ? await File.ReadAllTextAsync(promptPath) 
                    : "You are TWA-Overlord AI Assistant. Respond in Turkish.";
            }
            catch
            {
                systemPrompt = "You are TWA-Overlord AI Assistant. Respond in Turkish.";
            }

            var requestBody = new
            {
                model = "llama3-70b-8192", // Groq üzerindeki güçlü model
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.5
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
            
            if (!response.IsSuccessStatusCode)
                return "AI Hatası: " + response.ReasonPhrase;

            var responseString = await response.Content.ReadAsStringAsync();
            dynamic? result = JsonConvert.DeserializeObject(responseString);
            if (result == null) return "AI Cevap Vermedi.";
            return result.choices[0].message.content.ToString();
        }
    }
}
