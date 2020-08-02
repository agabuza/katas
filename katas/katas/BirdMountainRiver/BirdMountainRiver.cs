using System.Collections.Generic;
using System.Linq;

namespace katas.BirdMountain
{
    public class BirdMountainRiver
    {
        public static int[] DryGround(char[][] terrain)
        {
            if (!terrain.Any()) return new int[4] { 0, 0, 0, 0 };

            var colsCount = terrain[0].Length;
            var rowsCount = terrain.Length;
            var matrix = new int[rowsCount, colsCount];

            var fieldsToCheck = new List<(int, int)>();
            var river = new List<(int, int)>();
            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colsCount; j++)
                {
                    if (terrain[i][j] == '-')
                    {
                        matrix[i, j] = -1;
                        river.Add((i, j));
                    }

                    if (terrain[i][j] == '^')
                    {
                        matrix[i, j] = 1;
                        fieldsToCheck.Add((i, j));
                    }

                    if (terrain[i][j] == ' ')
                    {
                        matrix[i, j] = 0;
                    }
                }


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
                        higherPoint = true;
                    }
                }
            }

            var dayZero = LandSpotsCount(matrix);
            var result = new List<int>();
            result.Add(dayZero);
            result.Add(dayZero);
            result.Add(dayZero);
            result.Add(dayZero);

            for (int level = 0; level < 3; level++)
            {
                var newRiver = new List<(int, int)>();
                foreach (var riverCell in river)
                    newRiver.AddRange(RiverFlood(matrix, riverCell.Item1, riverCell.Item2, level));

                river.AddRange(newRiver);    
                result[level + 1] = LandSpotsCount(matrix);
            }

            return result.ToArray();
        }

        private static int LandSpotsCount(int[,] matrix)
        {
            var count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != -1)
                    {
                        count++;
                    }

            return count;
        }

        public static IEnumerable<(int, int)> RiverFlood(int[,] terrain, int col, int row, int level)
        {
            foreach (var floodedCell in FloodCell(terrain, col, row - 1, level)) yield return floodedCell;
            foreach (var floodedCell in FloodCell(terrain, col, row - 1, level)) yield return floodedCell;
            foreach (var floodedCell in FloodCell(terrain, col - 1, row, level)) yield return floodedCell;
            foreach (var floodedCell in FloodCell(terrain, col + 1, row, level)) yield return floodedCell;
            foreach (var floodedCell in FloodCell(terrain, col, row + 1, level)) yield return floodedCell;
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

        public static IEnumerable<(int, int)> FloodCell(int[,] terrain, int col, int row, int level)
        {
            if (col >= 0 && row >= 0 && col < terrain.GetLength(0) && row < terrain.GetLength(1))
            {
                if (terrain[col, row] <= level && terrain[col, row] != -1)
                {
                    terrain[col, row] = -1;

                    yield return (col, row);

                    foreach (var floodedCell in FloodCell(terrain, col, row - 1, level)) yield return floodedCell;
                    foreach (var floodedCell in FloodCell(terrain, col, row - 1, level)) yield return floodedCell;  // n
                    foreach (var floodedCell in FloodCell(terrain, col - 1, row, level)) yield return floodedCell; // w
                    foreach (var floodedCell in FloodCell(terrain, col + 1, row, level)) yield return floodedCell; // e
                    foreach (var floodedCell in FloodCell(terrain, col, row + 1, level)) yield return floodedCell; // s
                }
            }
        }


        public static int GetCellValue(int[,] matrix, int col, int row)
        {
            if (col >= 0 && row >= 0 && col < matrix.GetLength(0) && row < matrix.GetLength(1))
                return matrix[col, row];

            return 0;
        }
    }
}
