using System.Collections.Generic;
using System.Linq;

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
            var timeUnit = int.MaxValue;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    var start = i;
                    while (i < bits.Length && bits[i] == '0') i++;
                    var size = i - start;

                    if (size < timeUnit)
                        timeUnit = size;
                }
            }

            var index = 0;
            string morse = string.Empty;
            var currentBit = ' ';
            while (index < bits.Length)
            {
                currentBit = bits[index];
                var length = 1;

                while ((index < bits.Length - 1) && bits[++index] == currentBit) length++;

                var lengthInTimeUnits = length / timeUnit;

                switch (currentBit)
                {
                    case '1':
                        morse += lengthInTimeUnits == 1 ? "." : "-";
                        break;
                    case '0':
                        morse += lengthInTimeUnits == 3 ? " " : lengthInTimeUnits == 7 ? "   " : "";
                        break;
                }
            }

            return morse;
        }

        public static string DecodeMorse(string morseCode)
        {
            return string.Empty;
        }
    }
}