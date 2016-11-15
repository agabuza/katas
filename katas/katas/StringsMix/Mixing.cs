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
        var g1 = s1.Where(char.IsLower)
            .GroupBy(x => x)
            .Select(x => new { Value = x.Key, Count = x.Count(), Number = 1 });
        var g2 = s2.Where(char.IsLower)
            .GroupBy(x => x)
            .Select(x => new {Value = x.Key, Count = x.Count(), Number = 2});

        var merged = g1.Union(g2)
            .GroupBy(x => x.Value)
            .Select(
            x =>
            {
                var maxCount = x.Max(c => c.Count);
                var number = x.All(c => c.Count == maxCount) && x.Count() > 1
                    ? "3"
                    : x.FirstOrDefault(c => c.Count == maxCount).Number.ToString();
                return new
                {
                    Value = x.Key,
                    Number = number,
                    Count = maxCount
                };
            })
            .Where(x => x.Count > 1)
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Number)
            .ThenBy(x => x.Value);

        return string.Join("/", merged.Select(x => $"{(x.Number == "3" ? "=" : x.Number)}:{new string(x.Value, x.Count)}"));
        }
    }
}
