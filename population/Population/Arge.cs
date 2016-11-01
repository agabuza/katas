using System;

namespace Population
{
    class Arge
    {
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int y = 0;
            long population = p0;
            for (; population <= p; y++)
            {
                population += (long) Math.Round(population * percent*0.01) + aug;
            }

            return y;
        }
    }
}