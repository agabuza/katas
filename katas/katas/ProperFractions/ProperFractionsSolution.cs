using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace katas.ProperFractions
{
    class ProperFractionsSolution
    {
        internal static long ProperFractions(long number)
        {
            var denoms = Denominators(number);
            return denoms.Count();
        }

        public static IEnumerable<long> Denominators(long n)
        {
            if (n == 1) return new List<long>();
            var notPrimes = new bool[n + 1];
            var denoms = new List<long>() { 1 };
            var totalCount = 0;
            var currentPrime = n % 2 != 0? 2 : 3;
            var blockedPrimes = new List<long>();

            while (currentPrime <= n)
            {
                totalCount++;
                denoms.Add(currentPrime);

                for (long i = 2; currentPrime * i <= n; i++)
                {
                    var number = currentPrime * i;
                    if (n % i != 0 && !notPrimes[number])
                    {
                        totalCount++;
                        denoms.Add(number);
                    }

                    notPrimes[number] = true;
                }
                currentPrime++;

                while (currentPrime <= n && notPrimes[currentPrime] || n % currentPrime == 0)
                {
                    if (n % currentPrime == 0)
                    {
                        blockedPrimes.Add(currentPrime);
                    }
                    currentPrime++;
                }
            }

            var result = denoms.Where(d => blockedPrimes.All(bp => d % bp != 0)).ToList();

            return result;
        }
    }
}
