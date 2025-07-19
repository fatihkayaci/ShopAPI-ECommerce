using Microsoft.AspNetCore.Mvc;
using ShopAPI.Application.Interfaces;
using ShopAPI.Application.DTOs;

namespace ShopAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            
            if (product == null)
                return NotFound($"Product with ID {id} not found");
                
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct(CreateProductDto dto)
        {
            try
            {
                var product = await _productService.CreateProductAsync(dto); // ← Service çağır
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // ← Business logic hatası
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, UpdateProductDto dto)
        {
            try
            {
                var product = await _productService.UpdateProductAsync(id, dto); // ← Service çağır
                return Ok(product);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id); // ← Service çağır

            if (!result)
                return NotFound($"Product with ID {id} not found");

            return NoContent();
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsByCategory(string category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category); // ← Service çağır
            return Ok(products);
        }
        
        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsByPriceRange(
            [FromQuery] decimal minPrice, 
            [FromQuery] decimal maxPrice)
        {
            try
            {
                var products = await _productService.GetProductsByPriceRangeAsync(minPrice, maxPrice);
                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> SearchProducts([FromQuery] string searchTerm)
        {
            try
            {
                var products = await _productService.SearchProductsAsync(searchTerm);
                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}