using System.Collections.Generic;
using System.Text;

/// <summary>
/// https://www.codewars.com/kata/54b72c16cd7f5154e9000457/
/// </summary>
namespace katas.MorseCode
{
    public class MorseCodeDecoder
    {
        static Dictionary<string, char> morseDict = new Dictionary<string, char> {
                {".-", 'a'},
                {"-...", 'b'},
                {"-.-.", 'c'},
                {"-..", 'd'},
                {".", 'e'},
                {"..-.", 'f'},
                {"--.", 'g'},
                {"....", 'h'},
                {"..", 'i'},
                {".---", 'j'},
                {"-.-", 'k'},
                {".-..", 'l'},
                {"--", 'm'},
                {"-.", 'n'},
                {"---", 'o'},
                {".--.", 'p'},
                {"--.-", 'q'},
                {".-.", 'r'},
                {"...", 's'},
                {"-", 't'},
                {"..-", 'u'},
                {"...-", 'v'},
                {".--", 'w'},
                {"-..-", 'x'},
                {"-.--", 'y'},
                {"--..", 'z'},
                {"-----", '0'},
                {".----", '1'},
                {"..---", '2'},
                {"...--", '3'},
                {"....-", '4'},
                {".....", '5'},
                {"-....", '6'},
                {"--...", '7'},
                {"---..", '8'},
                {"----.", '9'},
                {"       ", ' '},
                {".-.-.-", '.'},
                {"--..--", ','},
                {"---...", ':'},
                {"..--..", '?'},
                {"..--.", '!'},
                {".----.", '\\'},
                {"-....-", '-'},
                {"-..-.", '/'},
                {".-..-.", '"'},
                {".--.-.", '@'},
                {"-...-", '='}
            };

        public static string DecodeBits(string bits)
        {
            bits = bits.TrimStart('0').TrimEnd('0');

            if (!bits.Contains("0")) return ".";

            var timeUnit = int.MaxValue;
            var index = 0;
            while (index < bits.Length)
            {
                var length = 0;
                var start = index;
                while (index < bits.Length && bits[start] == bits[index])
                {
                    index++;
                    length++;
                }

                if (length < timeUnit)
                    timeUnit = length;
            }

            index = 0;
            var morse = new StringBuilder();
            while (index < bits.Length)
            {
                char currentBit = bits[index];
                var length = 0;
                while (index < bits.Length && bits[index] == currentBit)
                {
                    length++;
                    index++;
                }

                var lengthInTimeUnits = length / timeUnit;

                switch (currentBit)
                {
                    case '1':
                        morse.Append(lengthInTimeUnits == 1 ? "." : "-");
                        break;
                    case '0':
                        morse.Append(lengthInTimeUnits == 3 ? " " : lengthInTimeUnits == 7 ? "   " : "");
                        break;
                }
            }

            return morse.ToString();
        }

        public static string DecodeMorse(string morseCode)
        {
            var result = new StringBuilder();
            var words = morseCode.Split(new string[] { "   " }, System.StringSplitOptions.None);

            foreach (var word in words)
            {
                foreach (var cr in word.Split(' '))
                {
                    result.Append(morseDict[cr]);
                }
                result.Append(" ");
            }

            return result.ToString().ToUpper().TrimEnd(' ');
        }
    }
}