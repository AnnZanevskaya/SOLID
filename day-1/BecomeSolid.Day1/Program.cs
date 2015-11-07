using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace BecomeSolid.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var bot = new Api("172034659:AAEh0DUUKUjNhoLX6LChwafGcWFB7AgSuPY");
            var weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";
            var me = await bot.GetMe();

            Console.WriteLine("Hello my name is {0}", me.Username);

            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    if (update.Message.Type == MessageType.TextMessage)
                    {
                        var inputMessage = update.Message.Text;
                        if (inputMessage.StartsWith("/currency"))
                        {
                            string url = String.Format("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDBYR%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");        
                            ResponceService service = new ResponceService(inputMessage, url, new CurrencyEntity());
                            var message = service.GetResponse();
                            var t = await bot.SendTextMessage(update.Message.Chat.Id, message);
                        }
                        else if (inputMessage.StartsWith("/weather"))
                        {
                            var messageParts = inputMessage.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
                            WebUtility.UrlEncode(city);
                            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", city, weatherApiKey);
                            ResponceService service = new ResponceService(inputMessage, url, new WeatherEntity());
                            var message = service.GetResponse();
                            var t = await bot.SendTextMessage(update.Message.Chat.Id, message);
                        }
                        else
                        {
                            await bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                            await Task.Delay(2000);
                            var t = await bot.SendTextMessage(update.Message.Chat.Id, update.Message.Text);
                            Console.WriteLine("Echo Message: {0}", update.Message.Text);
                        }

                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }

           
    }

}
