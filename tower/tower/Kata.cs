using System.Linq;

namespace tower
{
    public class Kata
    {
        public static string[] TowerBuilder(int nFloors)
        {
            var width = 2 * (nFloors - 1) + 1;
            return Enumerable.Range(0, nFloors)
                .Select((i, x) =>
                    {
                        return new string('*', 2 * i + 1).PadLeft(width - nFloors + i + 1, ' ').PadRight(width, ' ');
                    })
                .ToArray();
        }
    }
}