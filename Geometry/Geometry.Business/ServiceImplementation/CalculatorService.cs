using Geometry.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Business.ServiceImplementation
{
    public class CalculatorService : ICalculatorService
    {
        public double CalculateCircleArea(double radius)
        {
            var circleArea = Math.PI * radius * radius;

            return circleArea;
        }

        public double CalculateTriangleArea(double a, double b, double c)
        {
            double halfPerimeter = (a + b + c) / 2;

            var triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - a) 
                * (halfPerimeter - b) * (halfPerimeter - c));

            return triangleArea;
        }

        public bool IsTriangleRightAngled(double a, double b, double c)
        {
            if((Math.Pow(a, 2) == Math.Pow(b, 2) + Math.Pow(c, 2)) ||
                (Math.Pow(b, 2) == Math.Pow(a, 2) + Math.Pow(c, 2)) ||
                (Math.Pow(c, 2) == Math.Pow(b, 2) + Math.Pow(a, 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
