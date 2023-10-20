using SingleGetQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleGetQuery.Core.Abstractions
{
    public interface IProductService
    {
        Task<Guid> GetCategoryIdByName(string categoryName);
        Task<List<ProductModel>> GetAllProductsByCategoryId(Guid categoryId);
    }
}
