namespace KidsCryptoClient.Models
{
    using System;
    using Newtonsoft.Json;

    public  class CryptoNews
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("url")]
        public Uri? Url { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }
    }
}
