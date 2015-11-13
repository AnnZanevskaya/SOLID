using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Commands;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

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
            var bot = new Api("172034659:AAEh0DUUKUjNhoLX6LChwafGcWFB7AgSuPY");
            var me = await bot.GetMe();
            CommandsDictionary dictionary = new CommandsDictionary();
            dictionary.AddCommand("/weather", new WeatherCommand(bot));
           
            Console.WriteLine("Hello my name is {0}", me.Username);

            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    ICommand command = dictionary.GetCommandIfExist(update.Message.Text);
                    command.Execute(update);


                    //if (update.Message.Type == MessageType.TextMessage)
                    //{
                    //    var inputMessage = update.Message.Text;
                    //    var isTextMessage = update.Message.Type == MessageType.TextMessage;
                    //    MessageAnalizer analizer = new MessageAnalizer(inputMessage);

                    //    if (analizer.CommandExist)
                    //    {
                    //        ResponceService service = new ResponceService(analizer.Url, analizer.Command);
                    //        var message = service.GetResponse();
                    //        var t = await bot.SendTextMessage(update.Message.Chat.Id, message);
                    //    }
                    //    else
                    //    {
                    //        await bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                    //        await Task.Delay(2000);
                    //        var t = await bot.SendTextMessage(update.Message.Chat.Id, update.Message.Text);
                    //        Console.WriteLine("Echo Message: {0}", update.Message.Text);
                    //    }
                    //}
                    offset = update.Id + 1;
                }
            }
            await Task.Delay(1000);
        }

    }
}
