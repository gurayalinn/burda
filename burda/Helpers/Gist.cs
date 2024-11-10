// Gist.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
    }
}
