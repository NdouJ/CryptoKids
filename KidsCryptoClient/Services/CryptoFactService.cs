using Newtonsoft.Json;


namespace KidsCryptoClient.Services
{
    public static class CryptoFactService
    {
        public static async Task<IEnumerable<KidsCryptoClient.Models.CryptoFact>> GetCryptoFacts()
        {
            IEnumerable<KidsCryptoClient.Models.CryptoFact> facts = Enumerable.Empty<KidsCryptoClient.Models.CryptoFact>();

            using (HttpClient client = new HttpClient())
            {
                //try
                //{
                    HttpResponseMessage response = await client.GetAsync("http://localhost:5076/api/CryptoFactss");
                    //if (response.IsSuccessStatusCode)
                    //{
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                        facts = JsonConvert.DeserializeObject<IEnumerable<KidsCryptoClient.Models.CryptoFact >>(responseBody);
                    //}
               // }
                //catch (HttpRequestException e)
               // {
                  //  Console.WriteLine($"Error in Http: {e.Message}");
               // }
            }

            return facts;
        }
    }
}
