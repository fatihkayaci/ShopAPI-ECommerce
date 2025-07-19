using Microsoft.AspNetCore.Mvc;
using ShopAPI.Application.Interfaces;
using ShopAPI.Application.DTOs;
using ShopAPI.Domain.Entities;

namespace ShopAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            var productDtos = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category,
                Image = p.Image,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            var productDto = new ProductResponseDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                Image = product.Image,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category,
                Image = dto.Image,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _productRepository.AddAsync(product);

            var responseDto = new ProductResponseDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category,
                Image = product.Image,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, responseDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, UpdateProductDto dto)
        {
            // Önce ürün var mı kontrol et
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with ID {id} not found");

            // DTO'dan Entity'e güncelle
            existingProduct.ProductName = dto.ProductName;
            existingProduct.Description = dto.Description;
            existingProduct.Price = dto.Price;
            existingProduct.Stock = dto.Stock;
            existingProduct.Category = dto.Category;
            existingProduct.Image = dto.Image;
            existingProduct.UpdatedAt = DateTime.UtcNow; // ← Güncelleme zamanı

            await _productRepository.UpdateAsync(existingProduct);

            // Response DTO döndür
            var responseDto = new ProductResponseDto
            {
                Id = existingProduct.Id,
                ProductName = existingProduct.ProductName,
                Description = existingProduct.Description,
                Price = existingProduct.Price,
                Stock = existingProduct.Stock,
                Category = existingProduct.Category,
                Image = existingProduct.Image,
                CreatedAt = existingProduct.CreatedAt,
                UpdatedAt = existingProduct.UpdatedAt
            };

            return Ok(responseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Önce ürün var mı kontrol et
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with ID {id} not found");

            await _productRepository.DeleteAsync(id);

            return NoContent(); // 204 No Content - Silme başarılı, döndürülecek veri yok
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsByCategory(string category)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(category);
            
            var productDtos = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category,
                Image = p.Image,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

            return Ok(productDtos);
        }
    
    }
}