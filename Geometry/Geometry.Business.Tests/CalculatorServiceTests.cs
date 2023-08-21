using Geometry.Business.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Geometry.Business.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void CalculateCircleArea_WithCorrectData_ReturnDouble()
        {
            var calculatorService = new CalculatorService();

            double radius = 5;
            double expectedArea = Math.PI * radius * radius;
            double actualArea = calculatorService.CalculateCircleArea(radius);
            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void CalculateTriangleArea_WithCorrectData_ReturnDouble()
        {
            var calculatorService = new CalculatorService();

            double a = 15;
            double b = 15;
            double c = 15;
            double halfPerimeter = (a + b + c) / 2;

            var expectedArea = Math.Sqrt(halfPerimeter * (halfPerimeter - a)
                * (halfPerimeter - b) * (halfPerimeter - c));

            double actualArea = calculatorService.CalculateTriangleArea(a, b, c);

            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void IsTriangleRightAngled_ReturnTrue()
        {
            var calculatorService = new CalculatorService();

            double a = 3;
            double b = 4;
            double c = 5;

            var expectedBool = (Math.Pow(c, 2) == Math.Pow(b, 2) + Math.Pow(a, 2));

            var actualBool = calculatorService.IsTriangleRightAngled(a, b, c);

            Assert.Equal(expectedBool, actualBool);
        }

        [Fact]
        public void IsTriangleRightAngled_ReturnFalse()
        {
            var calculatorService = new CalculatorService();

            double a = 4;
            double b = 4;
            double c = 5;

            var expectedBool = (Math.Pow(c, 2) == Math.Pow(b, 2) + Math.Pow(a, 2));

            var actualBool = calculatorService.IsTriangleRightAngled(a, b, c);

            Assert.Equal(expectedBool, actualBool);
        }
    }
}
