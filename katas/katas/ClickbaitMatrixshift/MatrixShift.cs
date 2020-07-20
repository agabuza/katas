using System;
using System.Linq;
using System.Text;

namespace katas.ClickbaitMatrixshift
{
    public static class MatrixShift
    {
        internal static char[][] Shift(char[][] m, int n)
        {
            var flatMtx = m.SelectMany(x => x).ToList();
            var shifts = 0;
            while (shifts++ < n)
            {
                var shiftChar = flatMtx.LastOrDefault();
                flatMtx.RemoveAt(flatMtx.Count - 1);
                flatMtx.Insert(0, shiftChar);
            }

            var size = m[0].Length;
            var result = new char[m.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                 result[i] = flatMtx.GetRange(i * size, size).ToArray();
            }

            return result;
        }
    }
}
