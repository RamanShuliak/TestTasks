using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Core.Abstractions
{
    public interface ICalculatorService
    {
        double CalculateCircleArea(double radius);
        double CalculateTriangleArea(double a, double b, double c);
        bool IsTriangleRightAngled(double a, double b, double c);
    }
}
