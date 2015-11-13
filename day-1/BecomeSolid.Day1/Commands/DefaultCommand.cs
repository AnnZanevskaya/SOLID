using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class DefaultCommand: ICommand
    {
        private readonly Api api;
        public DefaultCommand(Api api)
        {
            this.api = api;
        }
        public void Execute(Update context)
        {
            throw new NotImplementedException();
        }
    }
}
