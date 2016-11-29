using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace katas.RomanNumeralsDecoder
{
    /// <summary>
    /// http://www.codewars.com/kata/51b6249c4612257ac0000005
    /// </summary>
    public class RomanDecode
    {
        public static Dictionary<string, int> baseDict = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 }
        };

        public static int Solution(string roman)
        {
            var result = 0;
            foreach (var numb in baseDict)
                while (roman.Length > 0 && roman.StartsWith(numb.Key))
                {
                    result += numb.Value;
                    roman = roman.Remove(0, numb.Key.Length);
                }

            return result;
        }
    }
}