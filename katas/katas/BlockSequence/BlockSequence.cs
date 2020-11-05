using System.Linq;
using System.Text;

namespace katas.BlockSequence
{
    class BlockSequence
    {
        public static int solve(long n)
        {
            if (n <= 2) return 1;
            long targetPos = n;
            long currentLength = 0;
            long totalLength = 0;
            long sqNum = 0;
            long zeroCount = 10;
            var newZero = 0;
            while(totalLength < n)
            {
                targetPos -= currentLength;
                sqNum++;

                if (sqNum >= zeroCount)
                {
                    newZero++;
                    zeroCount *= 10;
                }

                var numLength = (newZero + 1);
                totalLength += currentLength + numLength;
                currentLength += numLength;
            }

            long pos = 0;
            long num = 0;
            zeroCount = 10;
            newZero = 0;
            while(pos < targetPos)
            {
                num++;

                if (num >= zeroCount)
                {
                    newZero++;
                    zeroCount *= 10;
                }

                pos += newZero + 1;
            }

            var numStr = num.ToString();
            var finalChar = numStr[(int)(numStr.Length - (pos - targetPos) - 1)];

            return finalChar - '0';
        }
    }
}
