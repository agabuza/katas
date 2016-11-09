using System.Linq;

namespace katas.SumStrings
{
    /// <summary>
    /// https://www.codewars.com/kata/5324945e2ece5e1f32000370/
    /// </summary>
    public static class Kata
    {

        public static string sumStrings(string a, string b)
        {
            var length = 0;

            // equalize number of digits since meeting time constraints            
            if (a.Length > b.Length)
            {
                b = new string(Enumerable.Range(0, a.Length - b.Length).Select(x => '0').ToArray()) + b;
                length = b.Length;
            }
            else
            {
                a = new string(Enumerable.Range(0, b.Length - a.Length).Select(x => '0').ToArray()) + a;
                length = a.Length;
            }

            var result = string.Empty;
            var caryOver = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                var sum = a[i] - '0' + b[i] - '0' + caryOver;
                caryOver = sum / 10;
                result = sum % 10 + result;
            }

            if (caryOver > 0)
            {
                result = caryOver + result;
            }

            return result.TrimStart('0');
        }
    }
}
