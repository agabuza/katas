using System.Collections.Generic;
using System.Linq;

namespace katas.PrimeStreaming
{
    class PrimeStream
    {
        public static IEnumerable<int> Stream()
        {
            var primes = new List<int>();
            var number = 2;
            while (true)
            {
                if (!primes.Any(p => number % p == 0))
                {
                    primes.Add(number);
                    yield return number;
                }

                number++;
            }
        }
    }
}
