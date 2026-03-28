using AzureAppServiceAPI.Data.Enteties;

namespace AzureAppServiceAPI.Core.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task AddCategory(Category category);
        Task DeleteCategory(int id);
    }
}
