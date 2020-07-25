using System.Collections.Generic;
using System.Linq;

/// <summary>
/// https://www.codewars.com/kata/5426d7a2c2c7784365000783
/// </summary>
namespace katas.BalancedParetheses
{
    public class Balanced
    {
        public static List<string> BalancedParens(int n)
        {
            var allPossibleCombinations = GenerateParentheses("", 0, 0, n);
            return allPossibleCombinations.Distinct().OrderBy(x => x).ToList();
        }

        public static IEnumerable<string> GenerateParentheses(string text, int openCount, int closedCount, int n)
        {
            if (openCount > n || closedCount > n) yield break;
            if (closedCount == n && openCount == n) yield return text;

            if (openCount == closedCount)
            {
                foreach (var balanced in GenerateParentheses(text + "(", openCount + 1, closedCount, n))
                    yield return balanced;

                yield break;
            }

            if (openCount == n)
            {
                foreach (var balanced in GenerateParentheses(text + ")", openCount, closedCount + 1, n))
                    yield return balanced;

                yield break;
            }

            foreach (var balanced in GenerateParentheses(text + "(", openCount + 1, closedCount, n))
            {
                yield return balanced;
            }

            foreach (var balanced in GenerateParentheses(text + ")", openCount, closedCount + 1, n))
            {
                yield return balanced;
            }
        }

    }
}
