
// Write function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
//
// For example:
// str1 is 'rkqodlw' and str2 is 'world' the output should return true.
// str1 is 'cedewaraaossoqqyt' and str2 is 'codewars' should return true.
// str1 is 'katas' and str2 is 'steak' should return false.
// Only lower case letters will be used(a-z). No punctuation or digits will be included.
// Performance needs to be considered

using System;
using System.Linq;
using System.Text;

namespace katas
{
    public class Scramblies
    {
        // Assuming this is a subset sum problem (sum of chars)
        public static bool Scramble(string str1, string str2)
        {
            var dct1 = str2.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
            var dct2 = str1.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
            return str2.All(x => dct2.ContainsKey(x) && dct2[x] >= dct1[x]);
        }
    }
}