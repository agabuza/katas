using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spinWords
{
    public class Kata
    {
        public static string SpinWords(string sentence)
        {
            return string.Join(" ", sentence.Split(' ').Select(x => x.Length >= 5 ? new string(x.Reverse().ToArray()) : x));
        }
    }
}
