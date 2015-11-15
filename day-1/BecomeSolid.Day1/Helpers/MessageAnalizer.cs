

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

        public static string GetSecondWord(this string word, string defaulValue)
        {
            int index = word.IndexOf(' ');
            if (index == -1)
                return defaulValue;
            word = word.Substring(index + 1);
            return word.GetFirstWord();

        }

        public static string GetWordsExeptFirst(this string words)
        {
            int index = words.IndexOf(' ');
            if (index == -1)
                return words;
            return words.Substring(index + 1);
        }
    }
}
