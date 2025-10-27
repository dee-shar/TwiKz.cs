using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace TwiKzApi
{
    public class TwiKz
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://twi.kz/api/v1";
        public TwiKz()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<string> ShortenUrl(string url)
        {
            var data = JsonContent.Create(new {url = url});
            var response = await httpClient.PostAsync($"{apiUrl}/shorten", data);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
