using AzureAppServiceAPI.Data.Enteties;

namespace AzureAppServiceAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
