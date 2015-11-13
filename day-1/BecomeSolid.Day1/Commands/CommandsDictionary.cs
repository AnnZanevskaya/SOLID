using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Commands
{
    public class CommandsDictionary
    {
        private Dictionary<string, ICommand> dictionary;

        public CommandsDictionary()
        {
            dictionary = new Dictionary<string, ICommand>();
        }

        public void AddCommand(string keyword, ICommand command)
        {
            dictionary.Add(keyword, command);
        }

        public void RemoveCommand(string keyword)
        {
            dictionary.Remove(keyword);
        }

        public bool IsCommandExist(string keyword)
        {
           return dictionary.ContainsKey(keyword);
        }
    }
}
