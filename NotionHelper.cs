using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinBoostPro
{
    internal class NotionHelper
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public NotionHelper(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.notion.com/v1/")
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
        }

        public async Task<List<string>> FetchCommandsAsync(string databaseId)
        {
            try
            {
                Console.WriteLine("🔄 Envoi de la requête API à Notion...");

                var response = await _httpClient.PostAsync(
                    $"databases/{databaseId}/query",
                    new StringContent("{}", System.Text.Encoding.UTF8, "application/json")
                );

                Console.WriteLine($"📡 Réponse reçue : {response.StatusCode}");

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"📜 Contenu brut reçu : \n{content.Substring(0, Math.Min(500, content.Length))}..."); // Affiche seulement 500 caractères max pour éviter les logs trop longs

                List<string> commands = new List<string>();
                var jsonDoc = JsonDocument.Parse(content);
                var pages = jsonDoc.RootElement.GetProperty("results");

                foreach (var page in pages.EnumerateArray())
                {
                    if (page.TryGetProperty("properties", out var properties) &&
                        properties.TryGetProperty("Commandes", out var commandes) &&
                        commandes.TryGetProperty("rich_text", out var richTextArray) &&
                        richTextArray.GetArrayLength() > 0)
                    {
                        var command = richTextArray[0].GetProperty("text").GetProperty("content").GetString();
                        commands.Add(command);
                    }
                }

                Console.WriteLine($"✅ {commands.Count} commandes récupérées depuis Notion !");
                return commands;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la récupération des données : {ex.Message}");
                throw;
            }
        }
    }
}