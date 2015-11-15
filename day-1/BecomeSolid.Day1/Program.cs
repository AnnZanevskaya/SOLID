using System;
using System.Threading.Tasks;
using BecomeSolid.Day1.BotContainer;
using BecomeSolid.Day1.Builder;
using BecomeSolid.Day1.Commands;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Helpers;
using BecomeSolid.Day1.Service;
using Telegram.Bot;

namespace BecomeSolid.Day1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run().Wait();
        }

        private static async Task Run()
        {
            TelegramBot bot = new TelegramBot(new Api("172034659:AAEh0DUUKUjNhoLX6LChwafGcWFB7AgSuPY"));
            var me = await bot.BotApi.GetMe();
            CommandsDictionary dictionary = new CommandsDictionary(bot);
            ArtIntCommandsDictionary aiDictionary = new ArtIntCommandsDictionary();
          

            dictionary.AddCommand("/weather", new WeatherCommand<WeatherEntity>(bot, new WeatherService(), new WeatherBuilder()));
            dictionary.AddCommand("/currency", new CurrencyCommand<CurrencyEntity>(bot, new CurrencyService(), new CurrencyBuilder()));
            dictionary.AddCommand("/ai", new ArtIntCommand<ArtIntEntity>(bot, new ArtIntBuilder(), new ArtIntService(aiDictionary)));
            Console.WriteLine("Hello my name is {0}", me.Username);

            var offset = 0;

            while (true)
            {
                var updates = await bot.BotApi.GetUpdates(offset);

                foreach (var update in updates)
                {
                    ICommand command = dictionary.GetCommandIfExist(update.Message.Text.GetFirstWord());
                    command.Execute(update);
                    
                    offset = update.Id + 1;
                }
            }
            await Task.Delay(1000);
        }

    }
}
