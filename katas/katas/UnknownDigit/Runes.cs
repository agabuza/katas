using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace katas.UnknownDigit
{
    /// <summary>
    /// https://www.codewars.com/kata/find-the-unknown-digit
    /// </summary>
    public class Runes
    {
        public static int solveExpression(string expression)
        {
            int missingDigit = -1;
            var dt = new DataTable();

            //Write code to determine the missing digit or unknown rune
            //Expression will always be in the form
            //(number)[opperator](number)=(number)
            //Unknown digit will not be the same as any other digits used in expression
            // number can't start with 0 (e.g 00,01,02,..)

            var regexp = new Regex(@"\d");
            var digits = regexp.Matches(expression).OfType<Match>().SelectMany(x => x.Value.Select(y => int.Parse(y.ToString()))).Distinct();
            var possibleDigits = Enumerable.Range(0, 10).Select(x => x).Except(digits);
            if (expression.Contains("??")) possibleDigits = possibleDigits.Except(new List<int>() { 0 }); // 00 can't be an option
            foreach (var possibleDigit in possibleDigits)
            {
                var result = dt.Compute(expression.Replace('?', possibleDigit.ToString()[0]), null);
                if ((bool)result) return possibleDigit;
            }

            return missingDigit;
        }
    }
}