using System.Linq;

namespace katas.BalancedNumber
{
    class Kata
    {
        public static string BalancedNumber(int number)
        {
            var strNumber = number.ToString();

            var midShift = strNumber.Length % 2 == 0 ? 1 : 0;
            var sumLeft = strNumber.Substring(0, strNumber.Length / 2 - midShift).Sum(x => (int)x);
            var sumRight = strNumber.Substring(strNumber.Length / 2 + midShift + strNumber.Length % 2, strNumber.Length / 2 - midShift).Sum(x => (int)x);

            return sumLeft == sumRight ? "Balanced" : "Not Balanced";
        }
    }
}
