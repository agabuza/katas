using System.Linq;

namespace katas.NextBiggerNumber
{
public class Kata
{
    public static long NextBiggerNumber(long n)
    {
        var digits = n.ToString().ToArray();
        for (var i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] < digits[i + 1])
            {
                for (int j = i; j < digits.Length; j++)
                    if (digits[i] < digits[j])
                    {
                        var minValue = digits[i];
                        digits[i] = digits[j];
                        digits[j] = minValue;
                        var firstPart = digits.Take(i).ToArray();
                        var secondPart = digits.Skip(i).Take(n.ToString().Length - i).ToArray();

                        return long.Parse(new string(firstPart) + new string(secondPart));
                    }
            }
        }

        return -1;
    }
}
}