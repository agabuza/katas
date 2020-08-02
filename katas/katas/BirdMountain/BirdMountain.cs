using System.Collections.Generic;
using System.Linq;
/// <summary>
/// https://www.codewars.com/kata/5c09ccc9b48e912946000157
/// </summary>
namespace katas.BirdMountain
{
    public class BirdMountain
    {
        public static int PeakHeight(char[][] mountain)
        {
            var colsCount = mountain[0].Length;
            var rowsCount = mountain.Length;
            var matrix = new int[rowsCount, colsCount];

            var fieldsToCheck = new List<(int, int)>();
            var highestPoint = 1;

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colsCount; j++)
                    if (mountain[i][j] == '^')
                    {
                        matrix[i, j] = 1;
                        fieldsToCheck.Add((i, j));
                    }

            if (fieldsToCheck.Count == 0) return 0;

            var elevation = 0;
            var higherPoint = true;
            while (higherPoint)
            {
                elevation++;
                higherPoint = false;
                for (int i = 0; i < fieldsToCheck.Count; i++)
                {
                    var min = MinNeighbour(matrix, fieldsToCheck[i].Item1, fieldsToCheck[i].Item2);

                    if (min == elevation)
                    {
                        matrix[fieldsToCheck[i].Item1, fieldsToCheck[i].Item2] = min + 1;
                        highestPoint = highestPoint < min + 1 ? min + 1 : highestPoint;
                        higherPoint = true;
                    }
                }
            }

            return elevation;
        }

        public static int MinNeighbour(int[,] mountain, int col, int row)
        {
            var neighbours = new List<int>() {
                    GetCellValue(mountain, col, row - 1), // n
                    GetCellValue(mountain, col - 1, row), // w
                    GetCellValue(mountain, col + 1, row), // e
                    GetCellValue(mountain, col, row + 1), // s
                };

            return neighbours.Min();
        }

        public static int GetCellValue(int[,] matrix, int col, int row)
        {
            if (col >= 0 && row >= 0 && col < matrix.GetLength(0) && row < matrix.GetLength(1))
                return matrix[col, row];

            return 0;
        }
    }
}
