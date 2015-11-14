using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.BotContainer;
using BecomeSolid.Day1.Builder;
using BecomeSolid.Day1.Entity;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class DefaultCommand: ICommand
    {
        private readonly Api api;
        public DefaultCommand(IBotContainer bot)
        {
            this.api = bot.BotApi;
        }
        public async void Execute(Update context)
        {
            var t = await api.SendTextMessage(context.Message.Chat.Id, context.Message.Text);
            Console.WriteLine("Echo Message: {0}", context.Message.Text);
        }
    }
}
