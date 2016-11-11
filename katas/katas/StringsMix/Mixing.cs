using System;
using System.Linq;

namespace katas.StringsMix
{
    /// <summary>
    /// https://www.codewars.com/kata/5629db57620258aa9d000014
    /// </summary>
    public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            var g1 = s1.Where(char.IsLower).GroupBy(x => x).Select(x => new { Value = x.Key, Count = x.Count(), Number = 1 });
            var g2 = s2.Where(char.IsLower).GroupBy(x => x).Select(x => new { Value = x.Key, Count = x.Count(), Number = 2 });

            var merged = g1.Join(g2,
                x => x.Value,
                y => y.Value,
                (x, y) => new
                {
                    Count = x.Count > y.Count ? x.Count : y.Count,
                    Number = x.Count == y.Count ? "3" : x.Count > y.Count ? x.Number.ToString() : y.Number.ToString(),
                    x.Value
                })
                .Where(x => x.Count > 1)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Number)
                .ThenBy(x => x.Value);

            var result = string.Join("/", merged.Select(x => $"{(x.Number == "3" ? "=" : x.Number)}:{new string(x.Value, x.Count)}"));

            return result;
        }
    }
}
