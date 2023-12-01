using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfTriangleLib
{
    public class Triangle
    {
        public static string GetType(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException("Invalid arguments - all sides of the triangle must be greater than 0");
            }

            if (side1 == side2 && side2 == side3)
            {
                return "Equilateral";
            }

            double max = side1;

            if (side2 > max)
            {
                max = side2;
            }

            if (side3 > max)
            {
                max = side3;
            }

            if (max * max > side1 * side1 + side2 * side2 || max * max > side1 * side1 + side3 * side3 || max * max > side2 * side2 + side3 * side3)
            {
                return "Obtuse";
            }
            else if (max * max == side1 * side1 + side2 * side2 || max * max == side1 * side1 + side3 * side3 || max * max == side2 * side2 + side3 * side3)
            {
                return "Right";
            }
            else
            {
                return "Acute";
            }
        }
    }
}
