using ShopAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<bool> IsProductNameExistsAsync(string name);
    }
}