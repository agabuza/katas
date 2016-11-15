using System;
using System.Collections.Generic;
using System.Linq;

namespace katas.CarMileageNumbers
{
    /// <summary>
    /// http://www.codewars.com/kata/catching-car-mileage-numbers
    /// </summary>
    public static class Kata
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            if (number < 98) return 0;

            var isInteresting = new Func<string, bool>(s =>
                int.Parse(s) > 99 &&
                (awesomePhrases.Any(x => x.ToString() == s)       // The digits match one of the values in the awesomePhrases array
                 || (s.Length > 1 && s.TrimEnd('0').Length == 1)  // Any digit followed by all zeros: 100, 90000
                 || IsPalindrome(s)                               // The digits are a palindrome
                 || IsSequence(s, true)                           // The digits are sequential, incrementing
                 || IsSequence(s, false)));                       // The digits are sequential, decrementing

            if (isInteresting(number.ToString())) return 2;

            if (isInteresting((number + 1).ToString()) || isInteresting((number + 2).ToString())) return 1;

            return 0;
        }

        private static Dictionary<char, int> incDict = new Dictionary<char, int>()
        {
            {'1', '2'},
            {'2', '3'},
            {'3', '4'},
            {'4', '5'},
            {'5', '6'},
            {'6', '7'},
            {'7', '8'},
            {'8', '9'},
            {'9', '0'},
            {'0', '0'}

        };

        private static Dictionary<char, int> decDict = new Dictionary<char, int>()
        {
            {'1', '0'},
            {'2', '1'},
            {'3', '2'},
            {'4', '3'},
            {'5', '4'},
            {'6', '5'},
            {'7', '6'},
            {'8', '7'},
            {'9', '8'},
            {'0', '0'}
        };

        public static bool IsSequence(string number, bool increment)
        {
            var inc = new Func<char, int>((char x) => incDict[x]);
            var dec = new Func<char, int>((char x) => decDict[x]);

            var func = increment ? inc : dec;            
            for (int i = 0; i < number.Length - 1; i++)
            {
                if ((char)func(number[i]) != number[i + 1]) return false;
            }

            return true;
        }

        public static bool IsPalindrome(string number)
        {
            var median = number.Length / 2;
            var cShift = number.Length % 2 == 0 ? 1 : 0;
            for (int i = 1; i <= median; i++)
            {
                if ((number[median - i] ^ number[median + i - cShift]) != 0) return false;
            }

            return true;
        }
    }
}