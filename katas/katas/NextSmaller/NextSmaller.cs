using System.Linq;

/// <summary>
/// https://www.codewars.com/kata/5659c6d896bc135c4c00021e
/// </summary>
namespace katas.NextSmaller
{
    public class NextSmallerKata
    {
        public static long NextSmaller(long n)
        {
            var digits = n.ToString().ToArray();

            for (int i = digits.Length - 2; i >= 0; i--)
            {
                if (digits[i + 1] < digits[i])
                {
                    var position = 0;
                    var min = 0;
                    var shouldSwap = false;
                    for (int j = i + 1; j < digits.Length; j++)
                        if (digits[i] > digits[j])
                        {
                            shouldSwap = true;
                            min = digits[j];
                            position = j;
                        }

                    if (shouldSwap)
                    {
                        var minValue = digits[i];
                        digits[i] = digits[position];
                        digits[position] = minValue;
                    }

                    var firstPart = digits.Take(i + 1).ToArray();

                    var secondPart = digits.Skip(i + 1)
                            .Take(n.ToString().Length - i - 1)
                            .OrderByDescending(x => x)
                            .ToArray();

                    return long.Parse(new string(firstPart) + new string(secondPart));
                }
            }

            return -1;
        }
    }
}
