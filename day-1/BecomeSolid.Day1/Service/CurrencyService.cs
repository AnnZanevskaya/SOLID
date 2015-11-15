using BecomeSolid.Day1.Helpers;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Service
{
    public class CurrencyService : IService<CurrencyEntity>
    {
        private string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}BYR%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

        public CurrencyService() { }
        public CurrencyService(string url)
        {
            if (url != string.Empty && url.StartsWith("http"))
                this.url = url;
        }
        public CurrencyEntity GetInformation(string keyForInformathion)
        {
            string responseString =
                RestHelper.GetResponse(string.Format(url, keyForInformathion.GetSecondWord(defaulValue: "USD")));

            var currencyResponce = JsonConvert.DeserializeObject<CurrencyResponce>(responseString);
            var details = currencyResponce.query.results.rate;

            return new CurrencyEntity()
            {
                Name = details.Name,
                Currency = details.RateCurrency
            };
        }
    }
}
