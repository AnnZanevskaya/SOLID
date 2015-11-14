using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BecomeSolid.Day1
{
    public class Rate
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Rate")]
        public string RateCurrency { get; set; }
        [JsonProperty("Date")]
        public string Date { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("Ask")]
        public string Ask { get; set; }
        [JsonProperty("Bid")]
        public string Bid { get; set; }
    }

    public class Results
    {
        [JsonProperty("rate")]
        public Rate rate { get; set; }
    }

    public class Query
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("created")]
        public DateTime created { get; set; }
        [JsonProperty("lang")]
        public string lang { get; set; }
        [JsonProperty("results")]
        public Results results { get; set; }
    }

    public class CurrencyResponce
    {
        [JsonProperty("query")]
        public Query query { get; set; }
    }

}
