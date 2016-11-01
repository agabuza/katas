
/// <summary>
/// https://www.codewars.com/kata/decimal-to-factorial-and-back/
/// </summary>

namespace katas.DecimalToFactorial
{
    public class Dec2Fact
    {    
        public static string dec2FactString(long nb)
        {
            var result = string.Empty;
            for (int i = 1; nb > 0; i++)
            {
                var rem = nb % i;
                if (rem >= 10)
                {
                    result = (char)(55 + rem) + result;
                }
                else
                {
                    result = rem + result;
                }

                nb = nb / i;
            }

            return result;
        }

        public static long factString2Dec(string str)
        {
            long val = 1;
            long result = 0;
            for (int i = 1; i < str.Length; i++)
            {
                val = val * i;
                var chV = str[str.Length - i - 1];
                if (chV <= 57)
                {
                    // 0..9
                    result += (chV - 48) * val;
                }
                else
                {
                    // A..Z
                    result += (chV - 55) * val;
                }
            }

            return result;
        }
    }
}
