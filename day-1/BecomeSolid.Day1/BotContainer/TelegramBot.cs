using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.BotContainer
{
    public class TelegramBot : IBotContainer
    {
        public Api BotApi { get; set; }
        public TelegramBot(Api api)
        {
            BotApi = api;
        }

    }
}
