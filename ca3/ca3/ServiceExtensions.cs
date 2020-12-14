using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ca3
{
    public static class ServiceExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-Auth-Token", "API KEY HERE");

            var response = await httpClient.SendAsync(request);
            response.Headers.Add("Access-Control-Allow-Origin", "*"); //Allows for CORS in response headers
            response.EnsureSuccessStatusCode();

            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            return JsonSerializer.Deserialize<T>(responseBytes);
        }
    }
}
