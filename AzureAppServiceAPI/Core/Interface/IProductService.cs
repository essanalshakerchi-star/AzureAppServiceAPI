using AzureAppServiceAPI.Data.Enteties;

namespace AzureAppServiceAPI.Core.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
