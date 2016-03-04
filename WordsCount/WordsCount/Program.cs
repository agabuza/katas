using System;
using System.Linq;

namespace WordsCount
{
    public class Programm
    {
        public static void Main(params string[] args)
        {
            Console.WriteLine("Enter sentence:");
            var text = Console.ReadLine();
            var parser = new TextParser();
            var result = parser.GetOccurrence(text).Select(x => $"{x.Key}:{x.Value}");
            Console.WriteLine(string.Join("\n", result));
            Console.ReadLine();
        }
    }
}
