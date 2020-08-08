using System;
using System.Collections.Generic;
using System.Linq;

namespace katas.SumByFactors
{
    public class SumOfDivided
    {
        internal static string sumOfDivided(int[] lst)
        {
            var maxNumber = lst.Max(x => Math.Abs(x));
            var primes = GetPrimes(maxNumber);

            var result = string.Join("", primes.Select(p => GetPrimeDivisionPair(lst, p)));
            return result;
        }

        internal static string GetPrimeDivisionPair(int[] list, int prime)
        {
            var sum = 0;
            var anyPrimeFactor = false;
            foreach(var number in list)
            {
                if (number % prime == 0)
                {
                    anyPrimeFactor = true;
                    sum += number;
                }
            }

            return anyPrimeFactor ? $"({prime} {sum})" : string.Empty;
        }

        internal static List<int> GetPrimes(int n)
        {
            var nonPrimes = new bool[n + 1];
            nonPrimes[0] = nonPrimes[1] = true;
            var currentPrime = 2;
            while (currentPrime <= n)
            {
                var increment = 2;
                while (currentPrime * increment <= n)
                {
                    nonPrimes[currentPrime * increment] = true;
                    increment++;
                }

                currentPrime++;

                while (currentPrime <= n && nonPrimes[currentPrime]) currentPrime++;
            }

            return nonPrimes.Select((x, i) => new { Number = i, IsPrime = !x })
                            .Where(x => x.IsPrime)
                            .Select(x => x.Number)
                            .ToList();
        }
    }
}
