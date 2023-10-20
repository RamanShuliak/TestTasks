using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingleGetQuery.Core.Abstractions;
using SingleGetQuery.Models;

namespace SingleGetQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Получить все товары определённой категории
        /// </summary>
        /// <param name="categoryName">Название категории</param>
        /// <returns>Список товаров с ценами и названием категории</returns>
        [HttpGet("{categoryName}")]
        public async Task<IActionResult> GetAllProductsByCategoryName(string categoryName)
        {
            try
            {
                var categoryId = await _productService.GetCategoryIdByName(categoryName);

                var productModels = await _productService.GetAllProductsByCategoryId(categoryId);

                return Ok(productModels);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
