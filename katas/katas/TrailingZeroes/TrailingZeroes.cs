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
