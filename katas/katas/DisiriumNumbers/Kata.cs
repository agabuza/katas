using System;
using System.Linq;

namespace katas.DisiriumNumbers
{
    /// <summary>
    /// https://www.codewars.com/kata/5a53a17bfd56cb9c14000003
    /// </summary>
    internal class Kata
    {
        public static string DisariumNumber(int number)
        {
            var sum = number.ToString()
                            .Select((x, i) => new { Digit = char.GetNumericValue(x), Pow = i + 1 })
                            .Sum(x => Math.Pow(x.Digit, x.Pow));
            return sum == number ? "Disarium !!" : "Not !!";
        }
    }
}
