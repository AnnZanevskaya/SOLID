using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BecomeSolid.Day1.Commands
{
    public class CommandsDictionary
    {
        private readonly Dictionary<string, ICommand> dictionary;
        private readonly Api api;

        public CommandsDictionary(Api api)
        {
            this.api = api;

            dictionary = new Dictionary<string, ICommand>()
            {
               {"/default", new DefaultCommand(api)} 
            };
        }

        public void AddCommand(string keyword, ICommand command)
        {
            dictionary.Add(keyword, command);
        }

        public void RemoveCommand(string keyword)
        {
            dictionary.Remove(keyword);
        }

        public ICommand GetCommandIfExist(string keyword)
        {
            if (IsCommandExist(keyword))
                return dictionary.FirstOrDefault(dict => dict.Key == keyword).Value;
            return dictionary.First().Value;
        }

        private bool IsCommandExist(string keyword)
        {
            return dictionary.ContainsKey(keyword);
        }
    }
}
