using System.Collections.Generic;
using System.Linq;

namespace katas.SumIntervals
{
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            if (intervals.Length == 0) return 0;

            var lastItem = intervals.Max(x => x.Item2);
            var firstItem = intervals.Min(x => x.Item1);

            var ranges = intervals.SelectMany(x => new List<(int, int)> { (x.Item1, -1), (x.Item2, 1) })
                                  .GroupBy(x => x.Item1)
                                  .ToDictionary(x => x.Key, x => x.Sum(y => y.Item2));

            var inRange = 0;
            var rangeSize = 0;
            for (int i = firstItem; i <= lastItem; i++)
            {
                if (ranges.ContainsKey(i)) inRange += ranges[i];                
                if (inRange < 0) rangeSize++;                
            }

            return rangeSize;
        }
    }
}
