using Geometry.Core.Abstractions;
using Geometry.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geometry.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        /// <summary>
        /// Return circle area given its radius
        /// </summary>
        /// <param name="radius"></param>
        /// <returns>double Circle area</returns>
        [HttpGet]
        public IActionResult CalculateCircleArea(double radius)
        {
            var circleArea = _calculatorService.CalculateCircleArea(radius);

            return Ok(circleArea);
        }

        /// <summary>
        /// Returns triangle area given its sides
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>double Triangle area</returns>
        [HttpGet]
        public IActionResult CalculateTriangleArea(double a, double b, double c)
        {
            var triangleArea = _calculatorService.CalculateTriangleArea(a, b, c);

            return Ok(triangleArea);
        }

        /// <summary>
        /// Determines if a triangle is a right angled
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>bool Is triangle a right angled</returns>
        [HttpGet]
        public IActionResult IsTriangleRightAngled(double a, double b, double c)
        {
            var isTriangleRightAngled = _calculatorService.IsTriangleRightAngled(a, b, c);

            return Ok(isTriangleRightAngled);
        }

        /// <summary>
        /// Return area of figure without knowing about it tipe in compile-time
        /// </summary>
        /// <param name="values"></param>
        /// <returns>double Figure area</returns>
        [HttpPost]
        public IActionResult CalculateFigureAreaInCompileTime([FromBody]double[] values)
        {
            if (values.Length == 1)
            {
                var circleArea = _calculatorService.CalculateCircleArea(values[0]);

                return Ok(circleArea);
            }
            else if(values.Length == 3)
            {
                var triangleArea = _calculatorService
                    .CalculateTriangleArea(values[0], values[1], values[2]);

                return Ok(triangleArea);
            }
            else
            {
                return BadRequest(new MessageModel()
                {
                    Message = "The are no formulas for calculation area of figure with such numbers of values."
                });
            }
        }
    }
}
