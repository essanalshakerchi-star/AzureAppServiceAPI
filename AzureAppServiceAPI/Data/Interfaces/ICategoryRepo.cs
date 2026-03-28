using AzureAppServiceAPI.Data.Enteties;

namespace AzureAppServiceAPI.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategories();
        Task AddCategory(Category category);
        Task DeleteCategory(int id);
    }
}
