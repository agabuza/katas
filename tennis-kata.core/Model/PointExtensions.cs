using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_kata.core.Model
{
    public static class PointExtensions
    {
        public static string GetPointString(this Points point)
        {
            switch (point)
            {
                case Points._0:
                    return "0";
                case Points._15:
                    return "15";
                case Points._30:
                    return "30";
                case Points._40:
                    return "40";
                case Points._A:
                    return "A";
                default:
                    return point.ToString();
            }
        }
    }
}
