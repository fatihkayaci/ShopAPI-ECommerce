using ShopAPI.Application.DTOs;
using ShopAPI.Application.Interfaces;
using ShopAPI.Domain.Entities;
using AutoMapper;

namespace ShopAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper; 
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);

        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if (product == null)
                return null;

            
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto dto)
        {
            
            var existingProduct = await _productRepository.IsProductNameExistsAsync(dto.ProductName);
            if (existingProduct)
            {
                throw new InvalidOperationException($"Product with name '{dto.ProductName}' already exists");
            }

            var product = _mapper.Map<Product>(dto);

            await _productRepository.AddAsync(product);

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            // 1. Business Rule: Ürün var mı kontrol et
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with ID {id} not found");
            }

            // 2. Business Rule: Aynı isimde başka ürün var mı kontrol et (kendisi hariç)
            var duplicateProduct = await _productRepository.IsProductNameExistsAsync(dto.ProductName);
            if (duplicateProduct && existingProduct.ProductName != dto.ProductName)
            {
                throw new InvalidOperationException($"Product with name '{dto.ProductName}' already exists");
            }

            // 3. Business Rule: Kategori boş ise "General" yap
            var category = string.IsNullOrEmpty(dto.Category) ? "General" : dto.Category;

            // 4. Entity'yi güncelle (AutoMapper kullanarak)
            _mapper.Map(dto, existingProduct); // ← UpdateProductDto'yu existingProduct'a map et
            
            // 5. Business rule: UpdatedAt'i şu anki zamana set et
            existingProduct.UpdatedAt = DateTime.UtcNow;
            existingProduct.Category = category; // Kategori business rule'unu uygula

            // 6. Repository'ye kaydet
            await _productRepository.UpdateAsync(existingProduct);

            // 7. Response DTO döndür
            return _mapper.Map<ProductResponseDto>(existingProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            // 1. Business Rule: Ürün var mı kontrol et
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false; // Ürün bulunamadı
            }
            
            // 3. Repository'den sil
            await _productRepository.DeleteAsync(id);

            return true; // Silme başarılı
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(category);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            // Business Rule: Fiyat aralığı kontrol et
            if (minPrice < 0)
            {
                throw new ArgumentException("Minimum price cannot be negative");
            }
            
            if (maxPrice < minPrice)
            {
                throw new ArgumentException("Maximum price cannot be less than minimum price");
            }

            var products = await _productRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<IEnumerable<ProductResponseDto>> SearchProductsAsync(string searchTerm)
        {
            // Business Rule: Arama terimi kontrol et
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException("Search term cannot be empty");
            }

            if (searchTerm.Length < 2)
            {
                throw new ArgumentException("Search term must be at least 2 characters");
            }

            var products = await _productRepository.SearchProductsAsync(searchTerm);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }
    }
}