using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Service;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class WeatherCommand : ICommand
    {
        private readonly Api api;

        IService<WeatherEntity> service = new WeatherService(); //#savekitten

        public WeatherCommand(Api api)
        {
            this.api = api;
        }
        public async void Execute(Update context)
        {

            WeatherEntity weatherInfo = service.GetInformation(context.Message.Text);

            string response = String.Format("Hi " + weatherInfo.Name + " in "+weatherInfo.Description + " temp " + weatherInfo.Temperature);

            var t = await api.SendTextMessage(context.Message.Chat.Id, response);
            Console.WriteLine("Echo Message: {0}", response);
        }

    }
}
