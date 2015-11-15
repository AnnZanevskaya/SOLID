using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Helpers
{
    public static class MessageAnalizer
    {
        public static string GetFirstWord(this string word)
        {
            if (word.IndexOf(" ") != -1)
                return word.Substring(0, word.IndexOf(" "));
            return word;
    
        }
    }
}
