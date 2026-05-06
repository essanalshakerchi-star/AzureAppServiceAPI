using AzureAppServiceAPI.Core.Interface;
using AzureAppServiceAPI.Data.DTO;
using AzureAppServiceAPI.Data.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace AzureAppServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound("Produkten hittades inte");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            await _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id },
                new
                {
                    id = product.Id,
                    name = product.Name,
                    description = product.Description,
                    price = product.Price,
                    categoryId = product.CategoryId
                });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO dto)
        {
            var befintligProduct = await _productService.GetProductById(dto.Id);
            if (befintligProduct == null) return NotFound("Produkten hittades inte");

            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            await _productService.UpdateProduct(product);
            return Ok("Produkt uppdaterad!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound("Produkten hittades inte");

            await _productService.DeleteProduct(id);
            return Ok("Produkt borttagen!");
        }
    }
}
