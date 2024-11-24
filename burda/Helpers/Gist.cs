// Gist.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using burda.Helpers;

namespace burda.Helpers
{
    public class Gist
    {
        private static readonly string username = "gurayalinn";
        private static readonly string gistID = "d8aa9446406b00d4042a72e5cbee2fa7";
        private static readonly string gistUrl = $"https://gist.githubusercontent.com/{username}/{gistID}/raw";

        private static readonly HttpClient client = new HttpClient();

        public async Task<string> FetchGistDataAsync()
        {
            try
            {
                client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true
                };

                var response = await client.GetStringAsync(gistUrl);
                //Console.WriteLine("Gist fetched.");
                return response;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Network error while fetching Gist data: {httpEx.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Gist data: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task SyncGist()
        {
            try
            {
                Gist gistService = new Gist();
                Json jsonParser = new Json();
                DbSync databaseSyncService = new DbSync();
                var jsonData = await gistService.FetchGistDataAsync();
                var gistCards = jsonParser.ParseRFIDCards(jsonData);
                await databaseSyncService.SyncWithDatabaseAsync(gistCards);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }

        public async Task SyncGistPeriodically(int interval)
        {
            while (true)
            {
                await SyncGist();
                await Task.Delay(interval);
            }
        }

    }
}
