using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public class MessageAnalizer
    {
        public string Url { get;private set; }
        public IEntity Entity { get; private set; }
        public bool CommandExist { get; private set; }
        private readonly List<string> commandsList = new List<string>()
            {
                "/weather",
                "/currency"
            };
        public MessageAnalizer(string message)
        {
            CommandExist = true;
            if (message.StartsWith(commandsList[0]))
            {
                var weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";
                var messageParts = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
                WebUtility.UrlEncode(city);

                Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", city, weatherApiKey);
                Entity = new WeatherEntity();
            }
            else if (message.StartsWith(commandsList[1]))
            {
                var messageParts = message.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var currency = messageParts.Length == 1 ? "USD" : messageParts.Skip(1).First();

                Url =
                    String.Format(
                        "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}BYR%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=",
                        currency);
                Entity = new CurrencyEntity();
            }
            else
                CommandExist = false;
        }

    }
}
