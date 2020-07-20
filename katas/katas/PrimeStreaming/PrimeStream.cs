using System.Collections.Generic;
using System.Linq;

namespace katas.PrimeStreaming
{
    class PrimeStream
    {
        public static IEnumerable<int> Stream()
        {

            /* Sieve of Eratospthenes
             1. Create a list of consecutive integers from 2 through n: (2, 3, 4, ..., n).
             2. Initially, let p equal 2, the smallest prime number.
             3. Enumerate the multiples of p by counting in increments of p from 2p to n, and mark them in the list(these will be 2p, 3p, 4p, ...; the p itself should not be marked).
             4. Find the first number greater than p in the list that is not marked. If there was no such number, stop. Otherwise, let p now equal this new number(which is the next prime), and repeat from step 3.
             5. When the algorithm terminates, the numbers remaining not marked in the list are all the primes below n.

            Incremental Sieve of Eratosthenes
             
            */
            var p = 2;
            while(true)
            {

            }
            return new List<int> { 2, 3, 5, 7, 11, 13, 17 };
        }
    }
}
