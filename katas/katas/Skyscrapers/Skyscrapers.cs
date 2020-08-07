using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace katas.Skyscrapers
{
    public class Skyscrapers
    {
        internal static int[][] SolvePuzzle(int[] clues)
        {
            var combinations = GetAllCombinations(new List<int> { 1, 2, 3, 4 }, 4).ToList();
            var matrixCombinations = GetAllCombinations(combinations, 4).ToList();

            foreach (var combination in matrixCombinations)
            {

                var vertical0 = combination[0];
                var vertical1 = combination[1];
                var vertical2 = combination[2];
                var vertical3 = combination[3];

                var horizontal = new List<List<int>>();

                for (int i = 0; i < combination.Count; i++)
                {
                    var newLine = new List<int>();
                    for (int j = 0; j < combination[0].Count; j++)
                    {
                        newLine.Add(combination[j][i]);
                    }
                    horizontal.Add(newLine);
                }

                var horizontal0Rev = new List<int>(horizontal[0]);
                var horizontal1Rev = new List<int>(horizontal[1]);
                var horizontal2Rev = new List<int>(horizontal[2]);
                var horizontal3Rev = new List<int>(horizontal[3]);

                horizontal0Rev.Reverse();
                horizontal1Rev.Reverse();
                horizontal2Rev.Reverse();
                horizontal3Rev.Reverse();

                var vertical0Rev = new List<int>(vertical0);
                var vertical1Rev = new List<int>(vertical1);
                var vertical2Rev = new List<int>(vertical2);
                var vertical3Rev = new List<int>(vertical3);

                vertical0Rev.Reverse();
                vertical1Rev.Reverse();
                vertical2Rev.Reverse();
                vertical3Rev.Reverse();

                var slices = new List<List<int>> {
                    vertical0,
                    vertical1,
                    vertical2,
                    vertical3,
                    horizontal0Rev,
                    horizontal1Rev,
                    horizontal2Rev,
                    horizontal3Rev,
                    vertical3Rev,
                    vertical2Rev,
                    vertical1Rev,
                    vertical0Rev,
                    horizontal[3],
                    horizontal[2],
                    horizontal[1],
                    horizontal[0]
                };

                var isCorrect = slices.All(x => x.Count == x.Distinct().Count()) 
                                && clues.Select((x, i) => CheckClue(slices[i], x)).All(x => x);

                if (isCorrect)
                {
                    return combination.Select(Enumerable.ToArray).ToArray();
                }
            }

            return null;
        }

        public static bool CheckClue(IEnumerable<int> elements, int clue)
        {
            if (clue == 0) return true;
            var visibleTowers = 0;
            var maxHigh = elements.FirstOrDefault();
            foreach (var element in elements)
                if (element >= maxHigh)
                {
                    maxHigh = element;
                    visibleTowers++;
                }

            return visibleTowers == clue;
        }

        public static IEnumerable<List<T>> GetAllCombinations<T>(IEnumerable<T> source, int targetLength)
        {
            if (targetLength == 1)
            {
                foreach (var element in source)
                {
                    yield return new List<T> { element };
                }

                yield break;
            }
            else
            {
                foreach (var element in source)
                    foreach (var resultCombination in GetAllCombinations(source.Where(x => !x.Equals(element)), targetLength - 1))
                    {
                        var list = new List<T> { element };
                        list.AddRange(resultCombination);
                        yield return list;
                    }
            }
        }
    }
}