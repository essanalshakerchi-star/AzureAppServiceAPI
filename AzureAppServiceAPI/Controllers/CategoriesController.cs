using AzureAppServiceAPI.Core.Interface;
using AzureAppServiceAPI.Data.DTO;
using AzureAppServiceAPI.Data.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace AzureAppServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDTO dto)
        {
            var category = new Category { Name = dto.Name };
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id },
                new { id = category.Id, name = category.Name });  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categories = await _categoryService.GetAllCategories();
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound("Kategorin hittades inte");

            await _categoryService.DeleteCategory(id);
            return Ok("Kategori borttagen!");
        }
    }
}
