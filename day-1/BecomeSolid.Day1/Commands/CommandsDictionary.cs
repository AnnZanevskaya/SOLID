using System.Collections.Generic;
using System.Linq;
using BecomeSolid.Day1.BotContainer;


namespace BecomeSolid.Day1.Commands
{
    public class CommandsDictionary
    {
        private readonly Dictionary<string, ICommand> dictionary;
        private readonly IBotContainer bot;

        public CommandsDictionary(IBotContainer bot)
        {
            this.bot = bot;

            dictionary = new Dictionary<string, ICommand>()
            {
               {"/default", new DefaultCommand(bot)} 
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
            keyword = keyword.ToLowerInvariant();
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
