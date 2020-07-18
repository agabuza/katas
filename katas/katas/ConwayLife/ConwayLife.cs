using System;
using System.Diagnostics;
using System.Linq;

namespace katas.ConwayLife
{
    public class ConwayLife
    {
        public static int[,] GetGeneration(int[,] cells, int generation)
        {
            var gen = 0;
            Print2DArray(cells);
            var previousGen = cells.Clone() as int[,];

            while (gen < generation)
            {
                gen++;
                var newGeneration = new int[cells.GetLength(0) + 2, cells.GetLength(1) + 2];

                for (int col = 0; col < newGeneration.GetLength(0); col++)
                    for (int row = 0; row < newGeneration.GetLength(1); row++)
                    {
                        newGeneration[col, row] = CellLife(previousGen, col - 1, row - 1);
                    };

                previousGen = newGeneration.Clone() as int[,];
            }

            Print2DArray(previousGen);
            return TrimZeroes(previousGen);
        }

        private static int[,] TrimZeroes(int[,] matrix)
        {
            int left = int.MaxValue,
                right = 0,
                top = int.MaxValue,
                bottom = 0;

            for (int col = 0; col < matrix.GetLength(0); col++)
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[col, row] == 1)
                    {
                        if (col < left) left = col;
                        if (row < top) top = row;
                        if (col > right) right = col;
                        if (row > bottom) bottom = row;
                    }
                }

            var colLength = right - left + 1;
            var rowLenght = bottom - top + 1;

            var trimmedArray = new int[colLength, rowLenght];

            for (int col = 0; col < colLength; col++)
                for (int row = 0; row < rowLenght; row++)
                {
                    trimmedArray[col, row] = matrix[col + left, row + top];
                }

            Print2DArray(trimmedArray);

            return trimmedArray;
        }

        private static int CellLife(int[,] previousGen, int col, int row)
        {
            var isAlive = GetCellValueOrDefault(previousGen, col, row);

            var liveCells = 0;

            liveCells += GetCellValueOrDefault(previousGen, col - 1, row - 1); // nw
            liveCells += GetCellValueOrDefault(previousGen, col, row - 1); // n
            liveCells += GetCellValueOrDefault(previousGen, col + 1, row - 1); // ne

            liveCells += GetCellValueOrDefault(previousGen, col - 1, row); // w
            liveCells += GetCellValueOrDefault(previousGen, col + 1, row); // e

            liveCells += GetCellValueOrDefault(previousGen, col - 1, row + 1); // sw
            liveCells += GetCellValueOrDefault(previousGen, col, row + 1); // s
            liveCells += GetCellValueOrDefault(previousGen, col + 1, row + 1); // se

            return isAlive == 1 ?
                                  liveCells < 2 || liveCells > 3 ? 0 : 1
                                : liveCells == 3 ? 1 : 0;
        }

        private static int GetCellValueOrDefault(int[,] matrix, int col, int row)
        {
            if (col >= 0 && row >= 0 && col < matrix.GetLength(0) && row < matrix.GetLength(1))
                return matrix[col, row];

            return 0;
        }

        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Debug.Write(matrix[i, j] + "\t");
                }
                Debug.WriteLine("");
            }
        }
    }
}
