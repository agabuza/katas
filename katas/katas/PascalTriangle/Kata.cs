using System.Collections.Generic;

namespace katas.PascalTriangle
{
    /// <summary>
    /// https://www.codewars.com/kata/5226eb40316b56c8d500030f
    /// </summary>
    public static class Kata
    {
        public static List<int> PascalsTriangle(int n)
        {
            var result = new List<int> {1};

            // C(row, index) = C(row, index - 1) * (row + 1 - index) / (index)
            for (int r = 1; r < n; r++)
            {
                var row = new List<int> { 1 };
                for (int i = 1; i <= r; i++)
                    row.Add(row[i - 1] * (r + 1 - i) / i);
                result.AddRange(row);
            }

            return result;
        }
    }
}