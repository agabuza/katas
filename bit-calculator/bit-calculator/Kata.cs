using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace bit_calculator
{
    public class Kata
    {
        public static int Calculate(string num1, string num2)
        {
            var diff = num1.Length - num2.Length;
            if (diff < 0)
            {
                num1 = new string('0', Math.Abs(diff)) + num1;
            }
            else if (diff > 0)
            {
                num2 = new string('0', Math.Abs(diff)) + num2;
            }

            double result = 0;
            var carryOver = 0;
            var length = num1.Length;
            for (int i = 0; i < length; i++)
            {
                var sum = char.GetNumericValue(num1[length - i - 1]) + char.GetNumericValue(num2[length - i - 1]) + carryOver;

                switch ((int)sum)
                {
                    case 0:
                    case 1:
                        carryOver = 0;
                        break;
                    case 2:
                        carryOver = 1;
                        sum = 0;
                        break;
                    case 3:
                        carryOver = 1;
                        sum = 1;
                        break;
                    default:
                        break;
                }

                result += Math.Pow(2, i) * sum;
            }

            if (carryOver > 0)
            {
                result += Math.Pow(2, length);
            }

            return (int)result;
        }
    }
}
