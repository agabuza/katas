using System.Collections.Generic;

/// <summary>
/// https://www.codewars.com/kata/5426d7a2c2c7784365000783
/// </summary>
namespace katas.BalancedParetheses
{
    public class Balanced
    {
        public static List<string> BalancedParens(int n)
        {
            // your code here
            return null;
        }

        public static bool IsBalanced(string text)
        {
            int pairs = 0;
            foreach(var c in text)
            {
                if (c == '(') pairs++;
                else if (c == ')') pairs--;

                if (pairs < 0) return false;
            }

            return pairs == 0;
        }
    }
}
