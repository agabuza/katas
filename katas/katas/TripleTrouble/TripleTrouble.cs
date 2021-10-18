using System.Collections.Generic;
using System.Linq;

namespace katas.TripleTrouble
{
    class TripleTrouble
    {
        public static int TripleDouble(long num1, long num2)
        {
            var num1Str = num1.ToString();
            var num2Str = num2.ToString();

            var previousDigit = ' ';
            var length = 0;
            var triplets = new List<char>();
            var pairs = new List<char>();
            foreach (var digit in num1Str)
            {
                if (digit != previousDigit)
                {
                    length = 1;
                    previousDigit = digit;
                }
                else
                {
                    length++;
                }

                if (length >= 3)
                {
                    length = 0;
                    triplets.Add(previousDigit);
                }
            }

            previousDigit = ' ';
            length = 0;
            foreach (var digit in num2Str)
            {
                if (digit != previousDigit)
                {
                    length = 1;
                    previousDigit = digit;
                }
                else
                {
                    length++;
                }

                if (length >= 2)
                {
                    length = 0;
                    pairs.Add(previousDigit);
                }
            }

            return triplets.Any(x => pairs.Contains(x)) ? 1 : 0;
        }
    }
}
