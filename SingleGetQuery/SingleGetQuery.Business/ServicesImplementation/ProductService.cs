using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SingleGetQuery.Core.Abstractions;
using SingleGetQuery.DataBase;
using SingleGetQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleGetQuery.Business.ServicesImplementation
{
    public class ProductService : IProductService
    {
        private readonly SingleGetQueryDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(SingleGetQueryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> GetCategoryIdByName(string categoryName)
        {
            var categoryId = await _context.Categories
                .AsNoTracking()
                .Where(category => category.Name.Equals(categoryName))
                .Select(category => category.Id)
                .FirstOrDefaultAsync();

            if (categoryId.Equals(Guid.Empty))
            {
                throw new Exception("The are no categories with such name.");
            }

            return categoryId;
        }

        public async Task<List<ProductModel>> GetAllProductsByCategoryId(Guid categoryId)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Where(product => product.CategoryId.Equals(categoryId))
                .Include(product => product.Category)
                .Select(product => _mapper.Map<ProductModel>(product))
                .ToListAsync();

            if (!products.Any())
            {
                throw new Exception("The are no products with such category");
            }

            return products;
        }
    }
}
