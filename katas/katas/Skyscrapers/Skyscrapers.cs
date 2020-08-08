using System.Collections.Generic;
using System.Linq;

namespace katas.Skyscrapers
{
    public class Skyscrapers
    {
        internal static int[][] SolvePuzzle(int[] clues)
        {
            var combinations = GetAllCombinations(new List<int> { 1, 2, 3, 4 }, 4).ToList();
            var matrixCombinations = GetAllCombinations(combinations, 4);

            foreach (var combination in matrixCombinations)
            {

                var hrz0 = combination[0];
                var hrz1 = combination[1];
                var hrz2 = combination[2];
                var hrz3 = combination[3];

                var vert = new List<List<int>>();

                for (int i = 0; i < combination.Count; i++)
                {
                    var newLine = new List<int>();
                    for (int j = 0; j < combination[0].Count; j++)
                    {
                        newLine.Add(combination[j][i]);
                    }
                    vert.Add(newLine);
                }

                var vert0Rev = new List<int>(vert[0]);
                var vert1Rev = new List<int>(vert[1]);
                var vert2Rev = new List<int>(vert[2]);
                var vert3Rev = new List<int>(vert[3]);

                vert0Rev.Reverse();
                vert1Rev.Reverse();
                vert2Rev.Reverse();
                vert3Rev.Reverse();

                var hrz0Rev = new List<int>(hrz0);
                var hrz1Rev = new List<int>(hrz1);
                var hrz2Rev = new List<int>(hrz2);
                var hrz3Rev = new List<int>(hrz3);

                hrz0Rev.Reverse();
                hrz1Rev.Reverse();
                hrz2Rev.Reverse();
                hrz3Rev.Reverse();

                var slices = new List<List<int>> {
                    vert[0],
                    vert[1],
                    vert[2],
                    vert[3],
                    hrz0Rev,
                    hrz1Rev,
                    hrz2Rev,
                    hrz3Rev,
                    vert3Rev,
                    vert2Rev,
                    vert1Rev,
                    vert0Rev,
                    hrz3,
                    hrz2,
                    hrz1,
                    hrz0
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