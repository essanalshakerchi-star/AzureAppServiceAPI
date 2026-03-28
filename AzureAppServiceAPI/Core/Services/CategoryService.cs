using AzureAppServiceAPI.Core.Interface;
using AzureAppServiceAPI.Data.Enteties;
using AzureAppServiceAPI.Data.Interfaces;

namespace AzureAppServiceAPI.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<Category>> GetAllCategories() => await _categoryRepo.GetAllCategories();
        public async Task AddCategory(Category category) => await _categoryRepo.AddCategory(category);
        public async Task DeleteCategory(int id) => await _categoryRepo.DeleteCategory(id);
    }
}
