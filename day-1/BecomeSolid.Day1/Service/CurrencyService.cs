using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Service
{
    public class CurrencyService: IService<CurrencyEntity>
    {
        private string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}BYR%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
        public CurrencyEntity GetInformation(string keyForInformathion)
        {
            var messageParts = keyForInformathion.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currency = messageParts.Length == 1 ? "USD" : messageParts.Skip(1).First();

            WebRequest request = WebRequest.Create(string.Format(url, currency));
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();

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
}
