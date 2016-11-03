using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace katas.CeasarCipher
{
    /// <summary>
    /// https://www.codewars.com/kata/5508249a98b3234f420000fb
    /// </summary>
    public class CaesarCipher
    {
        public static List<string> movingShift(string s, int shift)
        {
            var alpha = "abcdefghijklmnopqrstuvwxyz";
            var alphaDict = alpha
                .Select((value, index) => new { value, index })
                .ToDictionary(x => x.value, x => x.index);

            var strBuilder = new StringBuilder();
            var lowerS = s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(lowerS[i]))
                {
                    var shiftedValue = alpha[(alphaDict[lowerS[i]] + i + shift) % 26].ToString();
                    strBuilder.Append(char.IsUpper(s[i]) ? shiftedValue.ToUpper() : shiftedValue.ToLower());
                }
                else
                {
                    strBuilder.Append(s[i]);
                }
            }

            var codedStr = strBuilder.ToString().Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var batchSize = codedStr.Length / 4;
            var result = codedStr
                .Select((value, index) => new { value, index })
                .GroupBy(w => w.index / batchSize)
                .Select(x => x.ToList()).ToList();

            if (result.Count > 4 && result[4].Any())
            {
                // equalize number of words in last two batches
                while (result[4].Count < result[3].Count)
                {
                    var word = result[3].LastOrDefault();
                    result[3].Remove(word);
                    result[4].Insert(0, word);
                }
            }

            return result.Select(g => string.Join(" ", g.Select(x => x.value)).Trim()).ToList();
        }

        public static string demovingShift(List<string> s, int shift)
        {
            var str = string.Join(" ", s).Trim();
            var alpha = "abcdefghijklmnopqrstuvwxyz";
            var alphaDict = alpha
                .Select((value, index) => new { value, index })
                .ToDictionary(x => x.value, x => x.index);

            var strBuilder = new StringBuilder();
            var lowerS = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(lowerS[i]))
                {
                    var index = alphaDict[lowerS[i]] - (i + shift) % 26;
                    index = index < 0 ? 26 + index : index; // -*- = +; negative values should be converted
                    var shiftedValue = alpha[index].ToString();
                    strBuilder.Append(char.IsUpper(str[i]) ? shiftedValue.ToUpper() : shiftedValue.ToLower());
                }
                else
                {
                    strBuilder.Append(str[i]);
                }
            }

            return strBuilder.ToString();
        }
    }
}
