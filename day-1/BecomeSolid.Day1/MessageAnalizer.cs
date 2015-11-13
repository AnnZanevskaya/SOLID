using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;

namespace BecomeSolid.Day1
{
    public class MessageAnalizer
    {
        public string Url { get; private set; }
        public ICommand Entity { get; private set; }
        public bool CommandExist { get; private set; }

        private readonly List<string> commandsList = new List<string>()
            {
                "/weather",
                "/currency",
                "/ai"
            };
        // + нужно что-то связанное с Url.. если передали Url, используем, нет, берем по умолчанию
        // + для команд - значение по умолчанию, передали - используем, нет, по умолчанию
        public MessageAnalizer(string message)
        {
            CommandExist = true;
            var messageParts = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (message.StartsWith(commandsList[0]))
            {
                var weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";
                var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
                WebUtility.UrlEncode(city);

                Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", city, weatherApiKey);
                Entity = new WeatherCommand();
            }
            else if (message.StartsWith(commandsList[1]))
            {
                var currency = messageParts.Length == 1 ? "USD" : messageParts.Skip(1).First();

                Url =
                    String.Format(
                        "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}BYR%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=",
                        currency);
                Entity = new CurrencyCommand();
            }
            else if (message.StartsWith(commandsList[2]))
            {
                Url = messageParts.Length == 1 ? "your name" : String.Concat(message.Skip(1));
                Entity = new AiCommand();                            
            }
            else
                CommandExist = false;
        }

    }
}
