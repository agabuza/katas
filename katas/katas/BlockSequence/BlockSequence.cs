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

            var sq = new StringBuilder();
            while(sq.Length <= currentLength && sqNum > 0)
            {
                sq.Insert(0, sqNum);
                sqNum--;
            }

            var res = sq[(int)(targetPos - 1)] - '0';
            return res;
        }
    }
}
