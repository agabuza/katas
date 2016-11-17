using System.Linq;

namespace katas.NextBiggerNumber
{

    /// <summary>
    /// https://www.codewars.com/kata/next-bigger-number-with-the-same-digits/train/csharp
    /// </summary>
    public class Kata
    {
        public static long NextBiggerNumber(long n)
        {
            var digits = n.ToString().ToArray();
            for (var i = digits.Length - 2; i >= 0; i--)
            {
                if (digits[i] < digits[i + 1])
                {
                    var position = 0;
                    var minD = ':'; // ['0'-'9'] < ':'
                    for (int j = i + 1; j < digits.Length; j++)
                        if (digits[i] < digits[j] && digits[j] < minD)
                        {
                            minD = digits[j];
                            position = j;
                        }

                    var minValue = digits[i];
                    digits[i] = digits[position];
                    digits[position] = minValue;

                    var firstPart = digits.Take(i + 1).ToArray();
                    var secondPart = digits.Skip(i + 1).Take(n.ToString().Length - i - 1).OrderBy(x => x).ToArray();

                    return long.Parse(new string(firstPart) + new string(secondPart));
                }
            }

            return -1;
        }
    }
}