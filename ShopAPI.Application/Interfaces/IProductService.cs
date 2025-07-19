using ShopAPI.Application.DTOs;

namespace ShopAPI.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto);
        Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductResponseDto>> GetProductsByCategoryAsync(string category);
        Task<IEnumerable<ProductResponseDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ProductResponseDto>> SearchProductsAsync(string searchTerm);
    }
}