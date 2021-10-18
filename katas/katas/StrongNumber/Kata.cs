using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katas.StrongNumber
{
    /// <summary>
    /// https://www.codewars.com/kata/5a4d303f880385399b000001
    /// </summary>
    class Kata
    {
        public static string StrongNumber(int number)
        {
            var sum = 0;
            var originalNumber = number;
            while(number > 0)
            {
                sum += Factorial(number % 10);
                number = number / 10;
            }

            return originalNumber == sum ? "STRONG!!!!" : "Not Strong !!";
        }

        public static int Factorial(int number)
        {
            if (number <= 1) return 1;
            return number * Factorial(number - 1);
        }
    }
}
