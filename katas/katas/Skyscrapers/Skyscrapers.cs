using System;
using System.Collections.Generic;

namespace katas.Skyscrapers
{
    public class Skyscrapers
    {
        internal static int[][] SolvePuzzle(int[] clues)
        {

        }

        public static void GetCombinations(List<int> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j<str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Console.Write(list[j]);
                    }
            }
            Console.WriteLine();
        }
    }
}
