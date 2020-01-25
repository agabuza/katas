//Write a program that will calculate the number of trailing zeros in a factorial of a given number.
//N! = 1 * 2 * 3 * ... * N
//Be careful 1000! has 2568 digits...

namespace katas.TrailingZeroes
{
    public static class TrailingZeroes
    {
        public static int GetTrailingFactorialZeroes(int n)
        {
            var trailingZeroes = 0;
            var baseDiv = 5;
            while (n >= baseDiv)
            {
                trailingZeroes += n / baseDiv;
                baseDiv *= 5;
            }

            return trailingZeroes;
        }
    }
}
