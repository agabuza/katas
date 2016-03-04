using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCount
{
    public class TextParser
    {
        public Dictionary<string, int> GetOccurrence(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("Input text should not be null.");
            }

            var words = GetWords(text.ToLower());
            return words.GroupBy(word => word)
                        .ToDictionary(g => g.Key, g => g.Count());
        }

        public IEnumerable<string> GetWords(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("Input text should not be null.");
            }

            var words = from m in Regex.Matches(text, @"\b[\w]*\b").Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;

            return words;
        }
    }
}
