using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KidsCryptoClient.Models;
using Newtonsoft.Json;

namespace KidsCryptoClient.Services
{
    public static class NewsService
    {


        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task <IEnumerable<CryptoNews>> GetNewsAsync()
        {
            IEnumerable<CryptoNews> news; 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://crypto-news-live9.p.rapidapi.com/news/CryptoNews"),
                Headers =
                {
                    { "X-RapidAPI-Key", "296ebc2835msha07ad0504e2916dp1a3f5fjsnaf60afca4e1c" },
                    { "X-RapidAPI-Host", "crypto-news-live9.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
               string body = await response.Content.ReadAsStringAsync();
                news = JsonConvert.DeserializeObject<List<CryptoNews>>(body);

            }

            return news;
        }
    }
}
