using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
   public class WeatherCommand: ICommand
   {
        private readonly Api api;

       public WeatherCommand(Api api)
       {
           this.api = api;
       }
        public async void Execute(Update context)
        {
            var messageParts = context.Message.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();

           // var weather = weatherService.GetWeatherForCity(city);


        }

    }
}
