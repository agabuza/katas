using System;
using System.Collections.Generic;
using System.Linq;

namespace katas.CountingChange
{
    /// <summary>
    /// https://www.codewars.com/kata/541af676b589989aed0009e7
    /// </summary>
    class Kata
    {
        internal static int CountCombinations(int value, int[] numbers)
        {
            return Decompose(numbers, value).Count();
        }

        internal static IEnumerable<bool> Decompose(IEnumerable<int> numbers, int target)
        {
            if (numbers.Count() == 0 || target == 0) yield break;
            var largestNumber = numbers.Max();

            if (target % largestNumber == 0) yield return true;

            for (int i = target / largestNumber; i >= 0; i--)
            {
                foreach (var decomp in Decompose(numbers.Where(x => x != largestNumber), target - i * largestNumber))
                    yield return decomp;
            }
        }
    }
}
