using System.Collections.Generic;
using System.Linq;

namespace BecomeSolid.Day1.Commands
{
    public class ArtIntCommandsDictionary
    {
        private readonly Dictionary<string, string> dictionary;

        public ArtIntCommandsDictionary()
        {
            dictionary = new Dictionary<string, string>()
            {
                {"default", "My name is Ann"}
            };
        }
        public void AddCommand(string keyword, string answer)
        {
            dictionary.Add(keyword, answer);
        }
        public void RemoveCommand(string keyword)
        {
            dictionary.Remove(keyword);
        }
        public string GetAswerOrDefault(string keyword)
        {
            keyword = keyword.ToLowerInvariant();
            if(IsCommandExist(keyword))
                return dictionary.FirstOrDefault(dict => dict.Key == keyword).Value;
            return dictionary.First().Value;
        }
        private bool IsCommandExist(string keyword)
        {
            return dictionary.ContainsKey(keyword);
        }
    }
}
