namespace katas.MatrixMultiply
{
    static class MatrixMutliplication
    {
        public static int[,] MatrixMultiplication(int[,] a, int[,] b)
        {
            var size = a.GetLength(0);
            var result = new int[size, size];

            for (int n = 0; n < size; n++)
                for (int m = 0; m < size; m++)
                {
                    var cellValue = 0;

                    for (var i = 0; i < size; i++)
                    {
                        cellValue += a[n, i] * b[i, m];
                    }

                    result[n, m] = cellValue;
                }

            return result;
        }
    }
}
