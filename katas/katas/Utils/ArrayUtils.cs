using System.Diagnostics;

namespace katas.Utils
{
    public class ArrayUtils
    {
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

        public static void Print2DArray<T>(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Debug.Write(matrix[i][j] + "\t");
                }
                Debug.WriteLine("");
            }
        }
    }
}
